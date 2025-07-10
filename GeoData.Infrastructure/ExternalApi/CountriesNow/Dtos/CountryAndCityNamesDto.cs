using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.CountriesNow.Dtos
{

    // from endpont https://countriesnow.space/api/v0.1/countries
    //gets Iso2 & 3 codes, names of each countries and an array of cities for each country

    public class CountryAndCityNamesWrapper
    {
        [JsonProperty("data")]
        public List<CountryAndCityNamesDto> CountryAndCityNamesData { get; set; }
    }

    public class CountryAndCityNamesDto
    {

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("cities")]
        public List<string> Cities { get; set; }


    }

   
}
