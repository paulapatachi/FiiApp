using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class StudentToClass
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int AcademicYear { get; set; }
        public int EnrollmentYear { get; set; }
        public int StudyYear { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
