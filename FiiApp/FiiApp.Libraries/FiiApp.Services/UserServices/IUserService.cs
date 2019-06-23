using FiiApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.UserServices
{
    public interface IUserService
    {
        UserDto AuthenticateUser(string username, string password);
        bool VerifyIfStudentExists(string registrationNumber, string email);
        bool VerifyIfStudentHasAccount(string registrationNumber, string email);
        string RegisterNewUser(string registrationNumber, string email, string password);
        StudentDto GetStudentInformation(int userId);
    }
}
