using GeoData.Application.Dtos;

namespace GeoData.Application.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
    }
}