using GeoData.Domain.Interfaces;
using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi.CountriesNow;
using GeoData.Infrastructure.ExternalApi.CountriesNow.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Application.ImportServices
{
    public class GeoDataImporter
    {
        private readonly CountriesNowApiClient _apiClient;
        private readonly ICountriesRepo _countriesRepo;
        private readonly ICitiesRepo _citiesRepo;

        public GeoDataImporter(CountriesNowApiClient apiClient,
        ICountriesRepo countriesRepo,
        ICitiesRepo citiesRepo)
        {
            _apiClient = apiClient;
            _countriesRepo = countriesRepo;
            _citiesRepo = citiesRepo;
        }

        public async Task ImportCountriesAndCitiesAsync()
        {
            var wrapper = await _apiClient.GetCountryAndCityNamesAsync();

            foreach (var dto in wrapper.CountryAndCityNamesData)
            {
                var (country, cities) = CountryAndCityMapper.MapTo_CountryAndCity(dto);

                await _countriesRepo.InsertCountryAsync(country);

                foreach (City city in cities)
                {
                    await _citiesRepo.InsertCityAsync(city);
                }
            }
        }
    }
}
