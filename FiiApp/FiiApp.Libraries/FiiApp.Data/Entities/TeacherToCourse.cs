using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class TeacherToCourse
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
