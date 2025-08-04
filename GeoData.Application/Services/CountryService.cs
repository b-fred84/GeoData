using GeoData.Application.Dtos;
using GeoData.Domain.Interfaces;
using GeoData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountriesRepo _countriesRepo;

        public CountryService(ICountriesRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var countries = await _countriesRepo.GetAllCountriesAsync();

            return countries.Select(c => new CountryDto
            {
                Name = c.Name,
                Iso2 = c.IsoCode2,
                Iso3 = c.IsoCode3,
                Area = c.Area,
                Population = c.Population
            });
        }
    }
}
