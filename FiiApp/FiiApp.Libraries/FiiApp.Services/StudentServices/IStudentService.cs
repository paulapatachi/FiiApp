using FiiApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.StudentServices
{
    public interface IStudentService
    {
        StudentDto GetStudentByUserId(int userId);
    }
}
