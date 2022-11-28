using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace PR22.Infrastructure.Convertors
{
    internal class Ratio : Convertor
    {
        
        public Ratio() { }

        public Ratio(double k)
        {
            this.k = k;
        }
        [ConstructorArgument("K")]
        public double k { get; set; } = 1;
        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value,c);

            return x * k;
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            if (value is null) return null;


            var x = System.Convert.ToDouble(value, c);

            return x / k;
        }
    }
}
