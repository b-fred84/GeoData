using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Application.Dtos
{
    public class CityDto
    {

        public string Name { get; set; }
        public int? Population { get; set; }
        public bool IsCapital { get; set; }

        //public int Id { get; set; }
        //public int? PopulationYear { get; set; }
        //public string CountryId { get; set; }

    }
}