using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class UniverseApi
  {
    private UniverseRepo _universeRepo;

    public UniverseApi()
    {
      _universeRepo = new UniverseRepo();
    }

    public async Task<IEnumerable<Universe>> ListAsync()
    {
      try
      {
        var universes = await _universeRepo.ListAsync();
        return universes;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
