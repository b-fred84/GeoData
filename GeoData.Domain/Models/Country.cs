using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Domain.Models
{
    public class Country
    {
        
        public string IsoCode2 { get; set; }
        public string Name { get; set; }
        public string IsoCode3 { get; set; }
        public int? Population { get; set; }
        public int? PopulationYear { get; set; }
        public string? Continent { get; set; }
        public string? Language {  get; set; }
        public int? Area { get; set; }

    }
}
