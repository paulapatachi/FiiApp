using System;
using System.ComponentModel.DataAnnotations;

namespace FiiApp.Data.Entities
{
    public partial class StudentTest
    {
        [Key
            ]
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(5)]
        public string FatherInitial { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(13)]
        public string NumarMatricol { get; set; }
    }
}
