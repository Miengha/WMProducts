using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class UsersApi
  {
    private UsersRepo _usersRepo;

    public UsersApi()
    {
      _usersRepo = new UsersRepo();
    }

    public async Task<string> AddAsync(User user)
    {
      try
      {
        var added = await _usersRepo.AddAsync(user);
        return added;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
      try
      {
        var users = await _usersRepo.ListAsync();
        return users;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
    public async Task<string> LoginAsync(User user)
    {
      try
      {
        var login = await _usersRepo.LoginAsync(user);
        return login;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

  }
}
