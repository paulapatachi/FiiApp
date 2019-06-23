using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Student = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Role { get; set; }
        [StringLength(255)]
        public string UserGuid { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
