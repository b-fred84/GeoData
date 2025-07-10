using GeoData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Domain.Interfaces
{
    public interface ICountriesRepo
    {
        Task InsertCountryAsync(Country country);
        Task UpdateCounrtyAsync(Country country);
        Task DeleteCountryAsync(string iso2);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetCountryByIdAsync(string iso2);

    }
}
