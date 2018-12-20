using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Domain
{
  internal class UniverseRepo
  {
    private DapperAdapter _dapperAdapter;

    public UniverseRepo()
    {
      _dapperAdapter = new DapperAdapter();
    }

    internal async Task<IEnumerable<Universe>> ListAsync()
    {
      var universes = await _dapperAdapter.QueryAsync<Universe>("rsp_Universes_Get");
      return universes;
    }
  }
}