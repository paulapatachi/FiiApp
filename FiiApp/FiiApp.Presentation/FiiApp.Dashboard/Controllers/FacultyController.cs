using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FiiApp.Dashboard.Helpers;
using FiiApp.Dashboard.Models;
using FiiApp.Services.FacultyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiiApp.Dashboard.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class FacultyController : ControllerBase
  {
    private readonly IFacultyService facultyService;
    private readonly IMapper mapper;

    public FacultyController(IFacultyService facultyService, IMapper mapper)
    {
      this.facultyService = facultyService;
      this.mapper = mapper;
    }

    [HttpGet("StudentFinalGrades")]
    public IActionResult GetStudentFinalGrades(int semester)
    {
      var userId = 0;
      if (Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var grades = facultyService.GetStudentFinalGrades(userId, semester);
        return Ok(mapper.Map<IEnumerable<FinalGradeModel>>(grades));
      }
      return BadRequest(new { message = "Something went wrong when trying to get student grades" });
    }

    [HttpGet("StudentClassAndEnrollmentYear")]
    public IActionResult GetStudentClassAndEnrollmentYear()
    {
      var userId = 0;
      if (Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var year = facultyService.GetStudentEnrollmentYear(userId);
        var currentClass = facultyService.GetStudentClass(userId);
        return Ok(new { academicYear = year, studentClass = currentClass });
      }
      return BadRequest(new { message = "Something went wrong when trying to get student class and enrollment year" });
    }

    [HttpGet("StudentGradesForCourse")]
    public IActionResult GetStudentGradesForCourse(int courseId)
    {
      var userId = 0;
      if (Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var grades = facultyService.GetStudentGradesForCourse(userId, courseId);
        return Ok(mapper.Map<IEnumerable<GradeModel>>(grades));
      }
      return BadRequest(new { message = "Something went wrong when trying to get student grades for course" });
    }

    [HttpGet("StudentMeansForGrades")]
    public IActionResult GetStudentGradesMeans()
    {
      var userId = 0;
      if (Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var means = facultyService.CalculateStudentMeans(userId);
        return Ok(mapper.Map<IEnumerable<GradesMeanModel>>(means));
      }
      return BadRequest(new { message = "Something went wrong when trying to get student grades means" });
    }

    [HttpGet("Teachers")]
    public IActionResult GetTeachers()
    {
      var teachers = facultyService.GetTeachers();
      return Ok(mapper.Map<IEnumerable<TeacherModel>>(teachers));
    }

    [HttpGet("StudentsGradesPerSemester")]
    public JsonResult GetStudentsGradesPerSemester()
    {
      var averages = facultyService.GetStudentsGradesPerSemester();
      return new JsonResult(averages);
    }

    [HttpGet("NumberOfEachGrade")]
    public JsonResult GetNumberOfEachGrade()
    {
      var numberOfGrades = facultyService.GetNumberOfEachGrade();
      return new JsonResult(numberOfGrades);
    }

    [HttpGet("CurrentUserGradesPerSemester")]
    public JsonResult GetCurrentUserGradesPerSemester()
    {
      var userId = 0;
      if (Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var grades = facultyService.GetCurrentUserGradesPerSemester(userId);
        return new JsonResult(grades);
      }
      return null ;
    }

  }
}
