using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Domain
{
  public class Class1
  {
    private DapperAdapter _dapperAdapter;

    public Class1()
    {
      _dapperAdapter = new DapperAdapter();
      var sql = "select n from Nums";
      var all = _dapperAdapter.QueryAsync<int>(sql);
      var x = all;
    }
  }
}
