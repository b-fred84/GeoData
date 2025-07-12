using GeoData.Domain.Interfaces;
using GeoData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.Repos
{
    public class CitiesRepo : ICitiesRepo
    {
        private readonly ISqlDataAccess _dataAccess;
        public CitiesRepo(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task DeleteCityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCityAsync(City city)
        {
            var parameters = new
            {
                Name = city.Name,
                CountryId = city.CountryId,
                Population = city.Population,
                PopulationYear = city.PopulationYear,
                IsCapital = city.IsCapital
            };

            await _dataAccess.SaveDataAsync("dbo.InsertCity", parameters);
        }

        public async Task UpdateCapitalCityStatusAsync(City city)
        {
            await _dataAccess.SaveDataAsync("dbo.UpdateCapitals", new { Name = city.Name, CountryId = city.CountryId });
        }


        public Task UpdateCityAsync(City city)
        {
            throw new NotImplementedException();
        }
    }
}
