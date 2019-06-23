using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Models
{
  public class GradesMeanModel
  {
    public int Semester { get; set; }
    public decimal? Average { get; set; }
    public decimal? ECTSMean { get; set; }
    public decimal? Points { get; set; }
    public int Credits { get; set; }
    public decimal? AverageYear { get; set; }
    public decimal? ECTSMeanYear { get; set; }
    public decimal? PointsYear { get; set; }
    public int CreditsYear { get; set; }
  }
}
