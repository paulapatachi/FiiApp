using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Models
{
  public class UserModel
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
  }
}
