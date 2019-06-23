using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class GradesMeanDto
    {
        public int StudyYear { get; set; }
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
