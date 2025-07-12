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


#region calling methods to populate/update the db uncomment methods as needed
//initial run to populate cities - runs and checks 70k+ rows
//shouldn't need to be run normally, just initially.  

//await importService.ImportCountriesAndCitiesAsync();


//update capitals
//await importService.UpdateCapitalCitiesAsync();

//update country populations
await importService.UpadateCountryPopulationAsync();
#endregion

Console.WriteLine("Update complete");