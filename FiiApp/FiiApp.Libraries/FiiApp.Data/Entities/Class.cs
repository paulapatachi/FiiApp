using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Class
    {
        public Class()
        {
            StudentToClass = new HashSet<StudentToClass>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<StudentToClass> StudentToClass { get; set; }
    }
}
