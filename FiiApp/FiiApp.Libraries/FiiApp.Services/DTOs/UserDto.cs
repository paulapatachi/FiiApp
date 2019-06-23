using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserGuid { get; set; }
    }
}
