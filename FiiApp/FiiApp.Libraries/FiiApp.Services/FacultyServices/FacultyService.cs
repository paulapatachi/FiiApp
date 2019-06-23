using AutoMapper;
using FiiApp.Data.Entities;
using FiiApp.Data.Infrastructure;
using FiiApp.Services.DTOs;
using FiiApp.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiiApp.Services.FacultyServices
{
    public class FacultyService : IFacultyService
    {
        private readonly IRepository<TeacherToCourse> teacherToCourseRepository;
        private readonly IRepository<StudentToClass> studentToClassRepository;
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IRepository<FinalGrade> finalGradeRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Grade> gradeRepository;
        private readonly IMapper mapper;

        public FacultyService(IRepository<TeacherToCourse> teacherToCourseRepository,
                              IRepository<StudentToClass> studentToClassRepository,
                              IRepository<Teacher> teacherRepository,
                              IRepository<FinalGrade> finalGradeRepository,
                              IRepository<Student> studentRepository,
                              IRepository<Grade> gradeRepository,
                              IMapper mapper)
        {
            this.teacherToCourseRepository = teacherToCourseRepository;
            this.studentToClassRepository = studentToClassRepository;
            this.teacherRepository = teacherRepository;
            this.finalGradeRepository = finalGradeRepository;
            this.studentRepository = studentRepository;
            this.gradeRepository = gradeRepository;
            this.mapper = mapper;
        }
        public string Ceva()
        {
            var teacherToCourse = teacherToCourseRepository.Query().Include(x => x.Teacher)
                                                            .Include(x => x.Course)
                                                            .FirstOrDefault(x => x.TeacherId == 1);
            var cc = teacherToCourse.Course.Name;
            return cc;
        }

        private int GetStudentIdByUserId(int userId)
        {
            var student = studentRepository.Query().FirstOrDefault(x => x.UserId.HasValue && x.UserId == userId);
            return student.Id;
        }

        public IEnumerable<FinalGradeDto> GetStudentFinalGrades(int userId, int semester)
        {
            var studentId = GetStudentIdByUserId(userId);
            if (!(studentId > 0))
                return null;
            var finalGrades = finalGradeRepository.Query()
                                             .Include(x => x.Student)
                                             .Include(x => x.Course)
                                             .Where(x => x.StudentId == studentId && x.Course.Semester == semester)
                                             .Select(x => mapper.Map<FinalGradeDto>(x))
                                             .ToList();
            foreach(var item in finalGrades){
                if (item.Grade < 5)
                    item.Credits = null;
            }
            return finalGrades;
        }

        public int GetStudentEnrollmentYear(int userId)
        {
            var studentId = GetStudentIdByUserId(userId);
            var year = studentToClassRepository.Query().FirstOrDefault(x => x.StudentId == studentId).EnrollmentYear;
            return year;
        }

        public string GetStudentClass(int userId)
        {
            var studentId = GetStudentIdByUserId(userId);
            var studentClass = studentToClassRepository.Query().Include(x => x.Class).FirstOrDefault(x => x.StudentId == studentId);
            return studentClass.Class.Name;
        }

        public IEnumerable<GradeDto> GetStudentGradesForCourse(int userId, int courseId)
        {
            var studentId = GetStudentIdByUserId(userId);
            if (!(studentId > 0))
                return null;
            var grades = gradeRepository.Query()
                                             .Include(x => x.Teacher)
                                             .Include(x => x.Evaluation)
                                             .Include(x => x.Evaluation.Type)
                                             .Where(x => x.StudentId == studentId && x.Evaluation.CourseId == courseId)
                                             .Select(x => mapper.Map<GradeDto>(x))
                                             .ToList();
            return grades;
        }

        public IEnumerable<GradesMeanDto> CalculateStudentMeans(int userId)
        {
            var studentId = GetStudentIdByUserId(userId);
            if (!(studentId > 0))
                return null;

            var finalGrades = finalGradeRepository.Query().Include(x => x.Course)
                                                          .Include(x => x.Course.Status)
                                                          .Where(x => x.StudentId == studentId).ToList();

            var averages = CalculateAverage(finalGrades);

            return averages;
        }

        private IEnumerable<GradesMeanDto> CalculateAverage(IEnumerable<FinalGrade> grades)
        {
            var averages = grades.Where(x => x.Course.Status.Status == CourseStatuses.Compulsory || x.Course.Status.Status == CourseStatuses.Optional)
                                 .GroupBy(x => new { x.Course.StudyYear, x.Course.Semester })
                                 .Select(x => new GradesMeanDto
                                 {
                                     StudyYear = x.Key.StudyYear,
                                     Semester = x.Key.Semester,
                                     Average = x.Average(y => y.Grade),
                                     ECTSMean = x.Average(y => y.Grade),
                                     Points = x.Sum(y => y.Grade * y.Course.NumberOfCredits),
                                     Credits = x.Sum(y => y.Course.NumberOfCredits)
                                 }).ToList();

            foreach (var year in averages.Select(x => x.StudyYear).Distinct())
            {
                var average = averages.Where(x => x.StudyYear == year).Sum(x => x.Average) / 2;
                var ECTS = averages.Where(x => x.StudyYear == year).Sum(x => x.ECTSMean) / 2;
                var points = averages.Where(x => x.StudyYear == year).Sum(x => x.Points);
                var credits = averages.Where(x => x.StudyYear == year).Sum(x => x.Credits);
                foreach (var item in averages.Where(x => x.StudyYear == year))
                {
                    item.AverageYear = average;
                    item.ECTSMeanYear = ECTS;
                    item.PointsYear = points;
                    item.CreditsYear = credits;
                }
            }
            return averages;
        }

        public IEnumerable<TeacherDto> GetTeachers()
        {
            var teachers = teacherRepository.Query().Select(x => mapper.Map<TeacherDto>(x)).ToList();
            return teachers;
        }

        public IEnumerable<GradesPerSemester> GetStudentsGradesPerSemester()
        {
            var finalGrades = finalGradeRepository.Query().Include(x => x.Course)
                                                          .Include(x => x.Course.Status)
                                                          .OrderBy(x => x.Course.Semester)
                                                          .GroupBy(x => x.StudentId);
            var result = new List<GradesPerSemester>();

            foreach(var student in finalGrades)
            {
                var averages = CalculateAverage(student);
                var response = new GradesPerSemester()
                {
                    Semester1 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 1).Average.Value, 2, MidpointRounding.AwayFromZero),
                    Semester2 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 2).Average.Value, 2, MidpointRounding.AwayFromZero),
                    Semester3 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 3).Average.Value, 2, MidpointRounding.AwayFromZero),
                    Semester4 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 4).Average.Value, 2, MidpointRounding.AwayFromZero),
                    Semester5 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 5).Average.Value, 2, MidpointRounding.AwayFromZero),
                    Semester6 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 6).Average.Value, 2, MidpointRounding.AwayFromZero),
                };
                result.Add(response);
            }

            return result;
        }

        public GradesPerSemester GetCurrentUserGradesPerSemester(int userId)
        {
            var averages = CalculateStudentMeans(userId);
            if(averages is null || averages.Count() ==0 )
            {
                return new GradesPerSemester();
            }

            var result = new GradesPerSemester()
            {
                Semester1 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 1).Average.Value, 2, MidpointRounding.AwayFromZero),
                Semester2 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 2).Average.Value, 2, MidpointRounding.AwayFromZero),
                Semester3 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 3).Average.Value, 2, MidpointRounding.AwayFromZero),
                Semester4 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 4).Average.Value, 2, MidpointRounding.AwayFromZero),
                Semester5 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 5).Average.Value, 2, MidpointRounding.AwayFromZero),
                Semester6 = decimal.Round(averages.FirstOrDefault(x => x.Semester == 6).Average.Value, 2, MidpointRounding.AwayFromZero),
            };

            return result;
        }

        public IEnumerable<NumberOfGrades> GetNumberOfEachGrade()
        {
            var grades = finalGradeRepository.Query().Where(x => x.Course.Status.Status == CourseStatuses.Compulsory || x.Course.Status.Status == CourseStatuses.Optional);
            var totalNumber = grades.Count();
            var allGrades = grades.GroupBy(x => x.Grade);
            var result = new List<NumberOfGrades>();

            foreach(var item in allGrades)
            {
                var data = new NumberOfGrades()
                {
                    Grade = item.Key.Value,
                    Number = item.Count()
                };
                data.Percent = decimal.Round((decimal)(data.Number * 100.0) / totalNumber, 2, MidpointRounding.AwayFromZero);
                result.Add(data);
            }

            return result;
        }
    }
}
