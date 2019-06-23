using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.MLServices
{
    public class FinalScoreStatistics
    {
        public float Year { get; set; }

        public float Gender { get; set; }

        public string Class { get; set; }

        public float MaxScore { get; set; }

        public float MinScore { get; set; }

        public float AverageScore { get; set; }

        public float AveragePassScore { get; set; }
    }
}
