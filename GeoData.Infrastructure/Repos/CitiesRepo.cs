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

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _dataAccess.LoadDataAsync<City, dynamic>("dbo.GetAllCities", new { });
        }

        public Task<City> GetCityByIdAsync(int id)
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

        public async Task UpadateCityPopulationAsync(City city)
        {
            var parameters = new
            {
                CountryId = city.CountryId,
                CityName = city.Name,
                Population = city.Population,
                PopulationYear = city.PopulationYear
            };

            await _dataAccess.SaveDataAsync("dbo.UpdateCityPopulation", parameters);
        }
    }
}
