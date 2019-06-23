using FiiApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.FacultyServices
{
    public interface IFacultyService
    {
        string Ceva();
        IEnumerable<FinalGradeDto> GetStudentFinalGrades(int userId, int semester);
        int GetStudentEnrollmentYear(int userId);
        string GetStudentClass(int userId);
        IEnumerable<GradeDto> GetStudentGradesForCourse(int userId, int courseId);
        IEnumerable<GradesMeanDto> CalculateStudentMeans(int userId);
        IEnumerable<TeacherDto> GetTeachers();
        IEnumerable<GradesPerSemester> GetStudentsGradesPerSemester();
        GradesPerSemester GetCurrentUserGradesPerSemester(int userId);
        IEnumerable<NumberOfGrades> GetNumberOfEachGrade();
    }
}
