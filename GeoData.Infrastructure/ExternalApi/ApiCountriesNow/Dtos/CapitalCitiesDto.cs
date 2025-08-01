﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos
{

    //from endpoint: https://countriesnow.space/api/v0.1/countries/capital
    public class CapitalCitiesWrapper
    {
        [JsonProperty("data")]
        public List<CapitalCitiesDto> Data { get; set; }
    }

    public class CapitalCitiesDto
    {
        [JsonProperty("iso2")]
        public string CountryId { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }
    }
}
