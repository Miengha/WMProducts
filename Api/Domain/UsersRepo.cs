using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using System.Data;

namespace Domain
{
  internal class UsersRepo
  {
    private DapperAdapter _dapperAdapter;

    public UsersRepo()
    {
      _dapperAdapter = new DapperAdapter();
    }

    internal async Task<string> AddAsync(User user)
    {
      var param = new DynamicParameters();
      param.Add("pLogin", user.LoginName, DbType.String, size: 255);
      param.Add("pPassword", user.Password, DbType.String, size: 255);
      param.Add("responseMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
      var added = await _dapperAdapter.QueryAsync<string>("rsp_uspAddUser", param);
      return added.FirstOrDefault();
    }

    internal async Task<IEnumerable<User>> ListAsync()
    {
      var users = await _dapperAdapter.QueryAsync<User>("rsp_Users_Get");
      return users;
    }

    internal async Task<string> LoginAsync(User user)
    {
      var param = new DynamicParameters();
      param.Add("pLoginName", user.LoginName, DbType.String, size: 255);
      param.Add("pPassword", user.Password, DbType.String, size: 255);
      param.Add("responseMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
      var login = await _dapperAdapter.ExecuteAsync("rsp_uspLogin", param);
      var loginString = param.Get<string>("@responseMessage");
      return loginString;
    }
  }
}