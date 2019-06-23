using System.Collections.Generic;

namespace FiiApp.Services.StudentTestServices
{
    public interface IStudentTestService
    {
        IEnumerable<StudentTestDto> GetAllStudents();
    }
}
