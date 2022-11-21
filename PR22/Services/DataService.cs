using PR22.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PR22.Services
{
    internal class DataService
    {
        private const string __DataSourceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                __DataSourceAddress, 
                HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = (SynchronizationContext.Current is null ? GetDataStream(): Task.Run(GetDataStream)).Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                yield return line.
                    Replace("Korea,", "Korea -").
                    Replace("Bonaire,","Bonaire -");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
          .First()
          .Split(',')
          .Skip(4)
          .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
          .ToArray();

        private static IEnumerable<(string Province, string Country,(double lat,double Lon) Place, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            IFormatProvider formatter = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ', '"');
                double latitude;
                double longitude;
                Double.TryParse(row[2],style,formatter, out  latitude);
                Double.TryParse(row[3],style, formatter, out  longitude);

                //  var longitude = double.Parse(row[3]);
                var counts = row.Skip(5)
                    .Select(s => int.Parse(s))
                    .ToArray();

                yield return (province, country_name, (latitude, longitude), counts);
            }

        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();
            var data = GetCountriesData().GroupBy(d => d.Country);

            foreach(var country_info in data)
            {
      
                var country = new CountryInfo
                {
                    Name = country_info.Key,
                    provinceCounts = country_info.Select(c => new PlaceInfo
                    {
                        Name = c.Province,
                        Location = new Point(c.Place.lat,c.Place.Lon),
                        Counts = dates.Zip(c.Counts,(date,count) => new ComfirmedCoiunt { Date = date,Count = count})
                    })
                };
                yield return country;
            }
        }
    }
}
