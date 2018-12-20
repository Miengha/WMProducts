using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
  [Route("api/v1/[controller]")]
  public class UsersController : Controller
  {
    private UsersApi _usersApi;

    public UsersController()
    {
      _usersApi = new UsersApi();
    }
    // GET: api/<controller>
    [HttpGet]
    public async Task <IEnumerable<User>> GetAsync()
    {
      var users = await _usersApi.ListAsync();
      return users;
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<controller>
    [HttpPost]
    public async Task<string> Post([FromBody]User user)
    {
      var add = await _usersApi.AddAsync(user);
      return add;
    }


    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
