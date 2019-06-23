using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class FinalGradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int AcademicYear { get; set; }
        public int Semester { get; set; }
        public decimal? Grade { get; set; }
        public int? Credits { get; set; }
        public DateTime? Date { get; set; }
        public string CourseName { get; set; }
    }
}
