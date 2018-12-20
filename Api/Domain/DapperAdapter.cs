using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class DapperAdapter
  {
    private readonly string _connectionString;

    public DapperAdapter()
    {
      _connectionString = "Data Source=.;Initial Catalog=WritersHaven;Integrated Security=True;MultipleActiveResultSets=True";
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string procedure, object param = null)
    {
      if (string.IsNullOrEmpty(_connectionString))
        return Enumerable.Empty<T>();

      using (var conn = new SqlConnection(_connectionString))
      {
        await conn.OpenAsync();
        var result = await conn.QueryAsync<T>(procedure, param, commandType: CommandType.StoredProcedure);
        return result;
      }
    }

    public async Task<int> ExecuteAsync(string procedure, object param = null)
    {
      if (string.IsNullOrEmpty(_connectionString))
        return 0;

      using (var conn = new SqlConnection(_connectionString))
      {
        await conn.OpenAsync();
        var result = await conn.ExecuteAsync(procedure, param, commandType: CommandType.StoredProcedure);
        return result;
      }
    }
  }
}
