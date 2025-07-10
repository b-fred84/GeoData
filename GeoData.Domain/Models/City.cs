using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public int? Population { get; set; }
        public int? PopulationYear { get; set; }
        public bool IsCapital { get; set; }
    }
}
