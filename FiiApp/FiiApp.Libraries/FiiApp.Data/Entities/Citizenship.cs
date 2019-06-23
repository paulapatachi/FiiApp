using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Citizenship
    {
        public Citizenship()
        {
            Student = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
