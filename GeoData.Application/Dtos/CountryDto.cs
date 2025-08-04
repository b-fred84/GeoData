using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Application.Dtos
{
    public class CountryDto
    {
        public string Iso2 { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public int? Population { get; set; }
        public string? Continent { get; set; }
        public int? Area { get; set; }

        //public int? PopulationYear { get; set; }
        //public string? Language { get; set; }
    }
}
