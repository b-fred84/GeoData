using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiRestCountries.Dtos
{
    public class AreaAndContinentDto
    {
        [JsonProperty("cca2")]
        public string Iso2 { get; set; }

        [JsonProperty("capital")]
        public string CapitalCitt { get; set; }

        [JsonProperty("region")]
        public string Continent { get; set; }

        [JsonProperty("subregion")]
        public string ContinentAmericas { get; set; }

    }
}
