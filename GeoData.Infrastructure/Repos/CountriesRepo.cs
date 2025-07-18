using GeoData.Domain.Interfaces;
using GeoData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.Repos
{
    public class CountriesRepo : ICountriesRepo
    {
        private readonly ISqlDataAccess _dataAccess;
        public CountriesRepo(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task DeleteCountryAsync(string iso2)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _dataAccess.LoadDataAsync<Country, dynamic>("dbo.GetAllCountries", new { });
        }

        public Task<Country> GetCountryByIdAsync(string iso2)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCountryAsync(Country country)
        {
            await _dataAccess.SaveDataAsync("dbo.InsertCountry", country);
        }

        
        public async Task UpdateCountryAsync(Country country)
        {
            var parameters = new
            {
                Iso2 = country.IsoCode2,
                Iso3 = country.IsoCode3,
                Population = country.Population,
                PopulationYear = country.PopulationYear,
                Continent = country.Continent,
                Area = country.Area,
            };

            await _dataAccess.SaveDataAsync("dbo.UpdateCountry", parameters);
        }

        
    }
}
