using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos
{
    public class CountryPopWrapper
    {
        [JsonProperty("data")]
        public List<CountryPopulationDto> Data { get; set; }
    }
    public class CountryPopulationDto
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]  //same as iso3 - not needed just use iso3
        public string Code { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("populationCounts")]
        public List<PopulationCountDto> PopulationCounts { get; set; }
    }

    public class PopulationCountDto
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
