using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Course
    {
        public Course()
        {
            Evaluation = new HashSet<Evaluation>();
            TeacherToCourse = new HashSet<TeacherToCourse>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
        public int StudyYear { get; set; }
        public int Semester { get; set; }
        public int StatusId { get; set; }

        public virtual CourseStatus Status { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<TeacherToCourse> TeacherToCourse { get; set; }
    }
}
