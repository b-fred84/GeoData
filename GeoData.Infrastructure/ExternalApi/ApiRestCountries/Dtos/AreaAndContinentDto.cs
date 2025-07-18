using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiRestCountries.Dtos
{

    //from endpoint https://restcountries.com/v3.1/alpha?codes={iso2}
    public class AreaAndContinentDto
    {
        [JsonProperty("cca2")]
        public string Iso2 { get; set; }

        [JsonProperty("region")]
        public string Continent { get; set; }

        [JsonProperty("subregion")]
        public string ContinentAmericas { get; set; }

        [JsonProperty("area")]
        public double Area {  get; set; }

        //have got this data from endpoints from countriesNow site.
        //this site might be better data though so although not needed now
        //may use these prps to overwrite data in my db
        //[JsonProperty("capital")]
        //public string CapitalCity { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

    }
}
