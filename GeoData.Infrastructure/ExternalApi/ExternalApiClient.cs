using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoData.Domain.Interfaces;
using GeoData.Infrastructure.ExternalApi.ApiRestCountries.Dtos;

namespace GeoData.Infrastructure.ExternalApi
{
    public class ExternalApiClient 
    {
        private readonly HttpClient _httpClient;

        public ExternalApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //generic method to use collecting from each url
        private async Task<T> GetGeoApiDataAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch data from url: {url}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        #region endpoints from countriesNow.space
        public async Task<CountryAndCityNamesWrapper> GetCountryAndCityNamesAsync()
        {
            return await GetGeoApiDataAsync<CountryAndCityNamesWrapper>("https://countriesnow.space/api/v0.1/countries");
        }

        public async Task<CapitalCitiesWrapper> GetCapitalCitiesAsync()
        {
            return await GetGeoApiDataAsync<CapitalCitiesWrapper>("https://countriesnow.space/api/v0.1/countries/capital");
        }

        public async Task<CountryPopWrapper> GetCountryPopulationAsync()
        {
            return await GetGeoApiDataAsync<CountryPopWrapper>("https://countriesnow.space/api/v0.1/countries/population");
        }

        public async Task<CityPopulationWrapper> GetCityPopulationAsync()
        {
            return await GetGeoApiDataAsync<CityPopulationWrapper>("https://countriesnow.space/api/v0.1/countries/population/cities");
        }

        #endregion

        #region endpoints from restcountries.com
        public async Task<AreaAndContinentDto> GetAreaAndContinentDataAsync(string iso2)
        {
            var result = await GetGeoApiDataAsync<List<AreaAndContinentDto>>($"https://restcountries.com/v3.1/alpha?codes={iso2}");

            return result?.FirstOrDefault();
        }



        #endregion
    }
}
