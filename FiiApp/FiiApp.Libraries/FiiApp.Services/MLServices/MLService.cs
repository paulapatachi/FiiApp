using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FiiApp.Services.MLServices
{
    public class MLService: IMLService
    {
        IEnumerable<MathInfo> _records;

        public MLService()
        {
            _records = GetRecords();
        }
        public string GetECTSPredictionForStudent(float PFScore)
        {
            var sampleData = new ECTSPrediction.Model.DataModels.ModelInput()
            {
                PF = PFScore
            };
            var prediction = ECTSPrediction.App.ECTSPrediction.GetECTSPrediction(sampleData);
            return prediction.ToString("0.##");
        }

        public string GetPFPredictionForStudent(PFPrediction.Model.DataModels.ModelInput sampleData)
        {
                //1,1,7,2,3,6,0,8.1,2.2, 7,3,0,7,0,6,2.4,3,55.55
            var prediction = PFPrediction.App.PFPrediction.GetPFPrediction(sampleData);
            return prediction.ToString("0.##");
        }

        public IEnumerable<MathInfo> GetRecords()
        {
            var path = Path.GetFullPath(@"..\..\MLPredictions\MathData.csv");

            TextReader reader = new StreamReader(path);
            var csvReader = new CsvReader(reader);
            csvReader.Configuration.Delimiter = ",";
            csvReader.Configuration.CultureInfo = new CultureInfo("en-EN");
            var records = csvReader.GetRecords<MathInfo>();

            return records;
        }

        public IEnumerable<AttendanceStatistics> GetAttendanceStatistics()
        {
            var records = _records;
            var items = records.GroupBy(x => x.Year);
            var result = new List<AttendanceStatistics>();

            foreach (var item in items)
            {
                var attendance = new AttendanceStatistics();
                attendance.Year = item.Key;
                attendance.TotalNumber = item.Count() * 7;
                attendance.SeminarS1 = item.Sum(x => x.NrPS1);
                attendance.SeminarS2 = item.Sum(x => x.NrPS2);
                attendance.ConsultationC1 = item.Sum(x => x.NrPC1);
                attendance.ConsultationC2 = item.Sum(x => x.NrPC2);
                result.Add(attendance);
            }

            return result.OrderBy(x => x.Year);
        }

        public IEnumerable<GenderStatistics> GetGenderStatistics()
        {
            var records = _records;
            var items = records.GroupBy(x => x.Year);
            var result = new List<GenderStatistics>();

            foreach (var item in items)
            {
                var statistics = new GenderStatistics()
                {
                    Year = item.Key,
                    Total = item.Count(),
                    Male = item.Where(x => x.Gender == 0).Count(),
                    Female = item.Where(x => x.Gender == 1).Count()
                };
                result.Add(statistics);
            }

            return result.OrderBy(x => x.Year);
        }

        public IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByYear()
        {
            var records = _records;
            var items = records.GroupBy(x => x.Year);
            var result = new List<FinalScoreStatistics>();

            foreach (var item in items)
            {
                var statistics = new FinalScoreStatistics()
                {
                    Year = item.Key,
                    MaxScore = item.Max(x => x.PF),
                    MinScore = item.Min(x => x.PF),
                    AverageScore = (float)Math.Round((decimal)item.Average(x => x.PF), 2, MidpointRounding.AwayFromZero),
                    AveragePassScore = (float)Math.Round((decimal)item.Where(x => x.PF >= 45).Average(x => x.PF), 2, MidpointRounding.AwayFromZero)
                };
                result.Add(statistics);
            }

            return result.OrderBy(x => x.Year);
        }

        public IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByClass()
        {
            var records = _records;
            var items = records.OrderBy(x => x.Class).GroupBy(x => x.Class);
            var result = new List<FinalScoreStatistics>();

            foreach(var item in items)
            {
                var statistics = new FinalScoreStatistics()
                {
                    Class = GetClassString(item.Key),
                    MaxScore = item.Max(x => x.PF),
                    MinScore = item.Min(x => x.PF),
                    AverageScore = (float)Math.Round((decimal)item.Average(x => x.PF), 2, MidpointRounding.AwayFromZero),
                    AveragePassScore = (float)Math.Round((decimal)item.Where(x => x.PF >= 45).Average(x => x.PF), 2, MidpointRounding.AwayFromZero)
                };
                result.Add(statistics);
            }

            return result;
        }

        public IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByGender()
        {
            var records = _records;
            var items = records.GroupBy(x => new { x.Year, x.Gender });
            var result = new List<FinalScoreStatistics>();

            foreach (var item in items)
            {
                var statistics = new FinalScoreStatistics()
                {
                    Year = item.Key.Year,
                    Gender = item.Key.Gender,
                    MaxScore = item.Max(x => x.PF),
                    MinScore = item.Min(x => x.PF),
                    AverageScore = (float)Math.Round((decimal)item.Average(x => x.PF), 2, MidpointRounding.AwayFromZero),
                    AveragePassScore = (float)Math.Round((decimal)item.Where(x => x.PF >= 45).Average(x => x.PF), 2, MidpointRounding.AwayFromZero)
                };
                result.Add(statistics);
            }
            return result.OrderBy(x => x.Year).ThenBy(x => x.Gender);
        }

        public IEnumerable<SeminarActivityStatistics> GetSeminarActivityStatistics()
        {
            var records = _records;
            var items = records.GroupBy(x => x.Year);
            var result = new List<SeminarActivityStatistics>();

            foreach (var item in items)
            {
                var statistics = new SeminarActivityStatistics()
                {
                    Year = item.Key,
                    MeritoriousSeminar = item.Sum(x => x.NrPSM1) + item.Sum(x => x.NrPSM2),
                    ActiveSeminar = item.Sum(x => x.NrPSA1) + item.Sum(x => x.NrPSA2),
                    ActiveConsultation = item.Sum(x => x.NrPCA1) + item.Sum(x => x.NrPCA2)
                };
                result.Add(statistics);
            }

            return result.OrderBy(x => x.Year);
        }

        public IEnumerable<PassedStudents> GetNumberOfPassedStudents()
        {
            var records = _records;
            var items = records.GroupBy(x => x.Year);
            var result = new List<PassedStudents>();

            foreach(var item in items)
            {
                var statistics = new PassedStudents()
                {
                    Year = item.Key,
                    Passed = item.Where(x => x.PF >= 45).Count(),
                    Unpassed = item.Where(x => x.PF < 45).Count()
                };
                result.Add(statistics);
            }

            return result.OrderBy(x => x.Year);
        }















        private string GetClassString(float number){
            var result = string.Empty;
            if(number <= 7)
            {
                result = "A" + number;
            }
            else if(number == 14)
            {
                result = "B7";
            }
            else
            {
                result = "B" + number%7;
            }
            return result;
        }

    }
}
