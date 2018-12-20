using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
  public class User
  {
    public User()
    {
      UserID = 0;
      LoginName = "";
      Password = "";
    }

    public int UserID { get; set; }
    public string LoginName { get; set; }
    public string Password { get; set; }
  }
}
