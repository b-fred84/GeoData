using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos
{
    //NOTE:  The idea was to only fill in the main cities,
    //the api has a lot of mismatching and inconcictencies in naming of countries, cities etc
    //running the service to match country and city names and get population left a LOT of nulls
    //Could do a lot of work around to get better data from this api,
    //look at cases where names dont match and write code to fix it
    //but that wasn't the point of what i wanted to learn here, have done this before and it is simple enough just very time consuming
    //Obviously if this project was going to be used for something irl then would write work arounds
    //but in that case i would get data from a different api with better data.
    //this was picked as it required no api key and had no limits on calls per day/sec etc
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
