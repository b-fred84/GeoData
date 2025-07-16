using GeoData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Domain.Interfaces
{
    public interface ICitiesRepo
    {
        Task InsertCityAsync(City city);
        Task UpdateCityAsync(City city);
        Task DeleteCityAsync(int id);
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task UpdateCapitalCityStatusAsync(City city);
        Task UpadateCityPopulationAsync(City city);
    }
}
