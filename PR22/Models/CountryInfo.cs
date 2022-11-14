using System.Collections.Generic;

namespace PR22.Models
{
    internal class CountryInfo : PlaceInfo 
    { 
        public IEnumerable<ProvinceInfo> provinceCounts { get; set; }    
    }
}
