using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiiApp.Data.Entities
{
    public partial class EvaluationType
    {
        public EvaluationType()
        {
            Evaluation = new HashSet<Evaluation>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Abbreviation { get; set; }

        public virtual ICollection<Evaluation> Evaluation { get; set; }
    }
}
