using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Grade
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int EvaluationId { get; set; }
        public decimal? Score { get; set; }
        public DateTime? EvalDate { get; set; }
        public decimal? GradeValue { get; set; }

        public virtual Evaluation Evaluation { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
