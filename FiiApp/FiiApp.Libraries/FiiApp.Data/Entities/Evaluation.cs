using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            Grade = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public decimal? MaxScore { get; set; }
        public int CourseId { get; set; }
        public int? TypeId { get; set; }

        public virtual Course Course { get; set; }
        public virtual EvaluationType Type { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
