using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Models
{
  public class FinalGradeModel
  {
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AcademicYear { get; set; }
    public int Semester { get; set; }
    public string Grade { get; set; }
    public string Credits { get; set; }
    public string Date { get; set; }
    public string CourseName { get; set; }
  }
}
