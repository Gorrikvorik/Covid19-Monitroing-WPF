using PR22.Models;
using System.Collections.Generic;


namespace PR22.Services.Interfaces
{
    interface IDataService
    {
        IEnumerable<CountryInfo> GetData();
    }
}
