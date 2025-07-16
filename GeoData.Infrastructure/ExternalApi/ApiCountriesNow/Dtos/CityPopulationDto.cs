using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos
{

    public class CityPopulationWrapper
    {
        [JsonProperty("data")]
        public List<CityPopulationDto> Data { get; set; }
    }

    public class CityPopulationDto
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("populationCounts")]
        public List<CityPopulationCountDto> PopulationCounts { get; set; }
    }

    public class CityPopulationCountDto
    {
        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("value")]
        public string Population { get; set; }

    }


}
