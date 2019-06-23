using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Grade = new HashSet<Grade>();
            TeacherToCourse = new HashSet<TeacherToCourse>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string Office { get; set; }
        [StringLength(255)]
        public string Rank { get; set; }
        [StringLength(255)]
        public string WebAddress { get; set; }
        [StringLength(255)]
        public string AreasOfInterest { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<TeacherToCourse> TeacherToCourse { get; set; }
    }
}
