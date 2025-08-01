﻿using GeoData.Domain.Models;
using GeoData.Infrastructure.ExternalApi.ApiCountriesNow.Dtos;
using GeoData.Infrastructure.ExternalApi.ApiRestCountries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Infrastructure.ExternalApi.Mapping
{
    public class GeoMapper
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


        public static City MapTo_City_UpdateCapitalCities(CapitalCitiesDto dto)
        {
            City city = new City
            {
                Name = dto.Capital,
                CountryId = dto.CountryId,
                IsCapital = true
            };

            return city;
        }


        public static Country MapTo_Country_PopulationData(CountryPopulationDto dto)
        {
            Country country = new Country
            {
                IsoCode3 = dto.Iso3,
                Population = null,
                PopulationYear = null
            };

            return country;
        }

        public static City MapTo_City_PopulationData(string cityName, string Iso2, string population, string year)
        {
            return new City
            {
                Name = cityName,
                CountryId = Iso2,
                Population = (int)decimal.Parse(population),
                PopulationYear = int.Parse(year)
            };
        }

        public static Country MapTo_Country_AreaAndContinent(AreaAndContinentDto dto)
        {
            if(dto.Continent != "Americas")
            {
                return new Country
                {
                    IsoCode2 = dto.Iso2,
                    Area = (int)dto.Area,
                    Continent = dto.Continent
                };
            }
            else if(dto.ContinentAmericas == "Central America"  || dto.ContinentAmericas == "Caribbean")
            {
                return new Country
                {
                    IsoCode2 = dto.Iso2,
                    Area = (int)dto.Area,
                    Continent = "North America"
                };
            }
            else
            {
                return new Country
                {
                    IsoCode2 = dto.Iso2,
                    Area = (int)dto.Area,
                    Continent = dto.ContinentAmericas
                };
            }
        }
            
       
      
    }
}
