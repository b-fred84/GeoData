using GeoData.Domain.Interfaces;
using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi;
using GeoData.Infrastructure.ExternalApi.Mapping;
using Microsoft.Data.SqlClient;
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


        //initial method for adding county/city names and iso2/3 codes to populate the db.
        //Is a lot of data (70k+ cities) from this endpoint.
        //should only run this to insert initial records (or periodically to check for updates in the extrnal api)
        public async Task ImportCountriesAndCitiesAsync()
        {
            var wrapper = await _apiClient.GetCountryAndCityNamesAsync();

            foreach (var dto in wrapper.CountryAndCityNamesData)
            {
                var (country, cities) = GeoMapper.MapTo_CountryAndCity(dto);

                await _countriesRepo.InsertCountryAsync(country);

                foreach (City city in cities)
                {
                    try
                    {
                        await _citiesRepo.InsertCityAsync(city);
                    }
                    catch (SqlException ex)
                    {
                        if(ex.Number == 2627 || ex.Number == 2601)
                        {
                            Console.WriteLine($"Duplicate city skipped: {city.Name} ({city.CountryId})");
                        }
                    }
                    
                }
            }
        }


        //updates the capital cities,  takes the name and iso2 and matches to the db rows
        //sets IsCapital to true where it matches
        public async Task UpdateCapitalCitiesAsync()
        {
            var wrapper = await _apiClient.GetCapitalCitiesAsync();

            foreach (var dto in wrapper.Data)
            {
                var city = GeoMapper.MapTo_City_UpdateCapitalCities(dto);

                await _citiesRepo.UpdateCapitalCityStatusAsync(city);
            }
        }

        public async Task UpdateCountryPopulationAsync()
        {
            var wrapper = await _apiClient.GetCountryPopulationAsync();

            foreach (var dto in wrapper.Data)
            {
                var country = GeoMapper.MapTo_Country_PopulationData(dto);

                var latestPop = dto.PopulationCounts.OrderByDescending(p => p.Year).FirstOrDefault();

                if (latestPop == null) continue;

                country.Population = (int)latestPop.Value;
                country.PopulationYear = latestPop.Year;

                await _countriesRepo.UpdateCountryAsync(country);
            }
        }

        public async Task UpdateCityPopulationsAsync()
        {
            var wrapper = await _apiClient.GetCityPopulationAsync();

            var countries = await _countriesRepo.GetAllCountriesAsync();
            var countryNametoIso2Dict = countries.ToDictionary(c => c.Name, c => c.IsoCode2);


            var cities = await _citiesRepo.GetAllCitiesAsync();
            var cityKeyDict = cities.ToDictionary(c => (c.CountryId, c.Name)); 

            foreach(var dto in wrapper.Data)
            {
                if (!countryNametoIso2Dict.TryGetValue(dto.Country, out var countryIso2)) continue;

                if (!cityKeyDict.TryGetValue((countryIso2, dto.City), out var cityInDb)) continue;

                var mostRecentPop = dto.PopulationCounts.OrderByDescending(pc => int.Parse(pc.Year)).FirstOrDefault();

                if (mostRecentPop == null) continue;

                City city = GeoMapper.MapTo_City_PopulationData(
                    dto.City,
                    countryIso2,
                    mostRecentPop.Population,
                    mostRecentPop.Year);

                await _citiesRepo.UpadateCityPopulationAsync(city);
            }
        }

        
    }
}
