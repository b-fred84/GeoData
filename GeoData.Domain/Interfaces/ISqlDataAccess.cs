using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoData.Domain.Interfaces
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionString = "Default");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionString = "Default");

    }
}
