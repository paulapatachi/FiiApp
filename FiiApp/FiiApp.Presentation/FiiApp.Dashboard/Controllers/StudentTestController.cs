using FiiApp.Services.StudentTestServices;
using Microsoft.AspNetCore.Mvc;

namespace FiiApp.Dashboard.Controllers
{
    [ApiController]
    public class StudentTestController : Controller
    {
        private readonly IStudentTestService studentService;

        public StudentTestController(IStudentTestService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("api/getstudents")]
        public JsonResult GetStudents()
        {
            var studList = studentService.GetAllStudents();
            return new JsonResult(studList);
        }
    }
}