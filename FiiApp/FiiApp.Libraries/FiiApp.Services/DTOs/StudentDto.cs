using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string FatherInitials { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }
        
        public string RegistrationNumber { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UserId { get; set; }

        public string Nationality { get; set; }

        public string Citizenship { get; set; }

        public string Class { get; set; }

        public int StudyYear { get; set; }
    }
}
