using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class CourseStatus
    {
        public CourseStatus()
        {
            Course = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Status { get; set; }
        [StringLength(10)]
        public string Abbreviation { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
