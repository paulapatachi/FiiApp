using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Models
{
  public class GradeModel
  {
      public int Id { get; set; }
      public decimal? MaxScore { get; set; }
      public decimal? YourScore { get; set; }
      public decimal? Grade { get; set; }
      public string EvalDate { get; set; }
      public string EvaluationName { get; set; }
      public string TeacherName { get; set; }
      public string EvaluationType { get; set; }
  }
}
