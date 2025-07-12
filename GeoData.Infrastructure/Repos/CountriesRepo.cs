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

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            throw new NotImplementedException();
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
                IsoCode3 = country.IsoCode3,
                Population = country.Population,
                PopulationYear = country.PopulationYear,
                Continent = country.Continent,
                Language = country.Language,
                Area = country.Area,
            };

            await _dataAccess.SaveDataAsync("dbo.UpdateCountry", parameters);
        }

        
    }
}
