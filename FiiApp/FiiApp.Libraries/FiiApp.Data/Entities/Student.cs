using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Student
    {
        public Student()
        {
            Grade = new HashSet<Grade>();
            StudentToClass = new HashSet<StudentToClass>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string FatherInitials { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string RegistrationNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }
        public int? NationalityId { get; set; }
        public int? CitizenshipId { get; set; }

        public virtual Citizenship Citizenship { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<StudentToClass> StudentToClass { get; set; }
    }
}
