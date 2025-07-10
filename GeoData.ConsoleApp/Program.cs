using GeoData.Application.ImportServices;
using GeoData.Domain.Interfaces;
using GeoData.Infrastructure.ExternalApi.CountriesNow;
using GeoData.Infrastructure.Repos;
using GeoData.Infrastructure.SqlDataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Load configuration
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(config);

services.AddScoped<ISqlDataAccess, SqlDataAccess>();

services.AddScoped<ICountriesRepo, CountriesRepo>();
services.AddScoped<ICitiesRepo, CitiesRepo>();

services.AddHttpClient<CountriesNowApiClient>();

services.AddScoped<GeoDataImporter>();

var provider = services.BuildServiceProvider();

var importService = provider.GetRequiredService<GeoDataImporter>();

//initial run to populate cities
//await importService.ImportCountriesAndCitiesAsync();

Console.WriteLine("Import complete");