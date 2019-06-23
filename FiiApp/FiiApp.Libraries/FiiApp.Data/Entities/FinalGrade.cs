using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class FinalGrade
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int AcademicYear { get; set; }
        public decimal? Grade { get; set; }
        public DateTime? Date { get; set; }
                
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
