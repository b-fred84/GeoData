using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi.CountriesNow.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoData.Domain.Interfaces;

namespace GeoData.Infrastructure.ExternalApi.CountriesNow
{
    public class CountriesNowApiClient 
    {
        private readonly HttpClient _httpClient;

        public CountriesNowApiClient(HttpClient httpClient)
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

        public async Task<CountryAndCityNamesWrapper> GetCountryAndCityNamesAsync()
        {
            return await GetGeoApiDataAsync<CountryAndCityNamesWrapper>("https://countriesnow.space/api/v0.1/countries");
        }

    }
}
