using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi.CountriesNow.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.CountriesNow.Mapping
{
    public class CountryAndCityMapper
    {
        public static (Country, List<City>) MapTo_CountryAndCity(CountryAndCityNamesDto dto)
        {
            Country country = new Country
            {
                IsoCode2 = dto.Iso2,
                IsoCode3 = dto.Iso3,
                Name = dto.CountryName,
                Population = null,
                PopulationYear = null,
                Continent = null,
                Language = null,
                Area = null
            };

            List<City> cityList = new List<City>();

            foreach (var cityName in dto.Cities)
            {
                City city = new City
                {
                    Name = cityName,
                    CountryId = dto.Iso2,
                    Population = null,
                    PopulationYear = null,
                    IsCapital = false
                };

                cityList.Add(city);
            }

            return (country, cityList);
        }

      
    }
}
