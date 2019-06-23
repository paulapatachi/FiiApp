using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int EvaluationId { get; set; }
        public decimal? MaxScore { get; set; }
        public decimal? YourScore { get; set; }
        public decimal? Grade { get; set; }
        public DateTime? EvalDate { get; set; }
        public string EvaluationName { get; set; }
        public string TeacherName { get; set; }
        public string EvaluationType { get; set; }
    }
}
