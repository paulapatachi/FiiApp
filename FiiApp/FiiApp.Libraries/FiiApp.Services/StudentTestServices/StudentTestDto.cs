using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.StudentTestServices
{
    public class StudentTestDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherInitial { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string NumarMatricol { get; set; }
    }
}
