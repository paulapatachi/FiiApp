using ECTSPrediction.Model.DataModels;
using PFPrediction.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.MLServices
{
    public interface IMLService
    {
        string GetECTSPredictionForStudent(float data);
        string GetPFPredictionForStudent(PFPrediction.Model.DataModels.ModelInput data);
        IEnumerable<AttendanceStatistics> GetAttendanceStatistics();
        IEnumerable<GenderStatistics> GetGenderStatistics();
        IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByYear();
        IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByClass();
        IEnumerable<FinalScoreStatistics> GetFinalScoreStatisticsByGender();
        IEnumerable<SeminarActivityStatistics> GetSeminarActivityStatistics();
        IEnumerable<PassedStudents> GetNumberOfPassedStudents();
    }
}
