using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using FiiApp.Data.Entities;
using FiiApp.Data.Infrastructure;
using FiiApp.Services.DTOs;
using FiiApp.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FiiApp.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<StudentToClass> studentToClassRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public UserService(IRepository<User> userRepository, 
                           IRepository<Student> studentRepository,
                           IRepository<StudentToClass> studentToClassRepository,
                           IUnitOfWork unitOfWork, 
                           IConfiguration configuration, 
                           IMapper mapper)
        {
            this.userRepository = userRepository;
            this.studentRepository = studentRepository;
            this.studentToClassRepository = studentToClassRepository;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public UserDto AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = userRepository.Query().SingleOrDefault(x => x.Username == username.ToLower());

            // check if username exists
            if (user is null)
                return null;

            // check if password is correct
            var hashPass = GetHashPassword(password, user.UserGuid);
            if (user.Password != hashPass)
                return null;

            // authentication successful
            return mapper.Map<UserDto>(user);
        }

        public string RegisterNewUser(string registrationNumber, string email, string password)
        {
            var student = studentRepository.Query().FirstOrDefault(x => x.RegistrationNumber == registrationNumber && x.Email == email.ToLower());
            var newUser = new User();
            newUser.Username = email.Split("@").First();
            newUser.UserGuid = Guid.NewGuid().ToString();
            newUser.Role = UserRoles.Student;
            newUser.Password = GetHashPassword(password, newUser.UserGuid);
            userRepository.Add(newUser);
            unitOfWork.Commit();
            student.UserId = newUser.Id;
            unitOfWork.Commit();
            return newUser.Username;
        }

        public bool VerifyIfStudentExists(string registrationNumber, string email)
        {
            var student = studentRepository.Query().FirstOrDefault(x => x.RegistrationNumber == registrationNumber && x.Email == email.ToLower());
            if (student is null)
                return false;
            return true;
        }

        public bool VerifyIfStudentHasAccount(string registrationNumber, string email)
        {
            var student = studentRepository.Query().FirstOrDefault(x => x.RegistrationNumber == registrationNumber && x.Email == email.ToLower());
            if (student.UserId.HasValue)
                return true;
            return false;
        }

        private string GetHashPassword(string password, string salt)
        {
            var rawData = $"{password}{salt}{configuration["Pepper"]}";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public StudentDto GetStudentInformation(int userId)
        {
            var student = studentRepository.Query()
                                            .Include(x => x.Nationality)
                                            .Include(x => x.Citizenship)
                                            .FirstOrDefault(x => x.UserId == userId);
            var studentClass = studentToClassRepository.Query().Include(x => x.Class).FirstOrDefault(x => x.StudentId == student.Id);
            var studentDto = mapper.Map<StudentDto>(student);
            studentDto.Class = (studentClass != null) ? studentClass.Class.Name : string.Empty;
            studentDto.StudyYear = studentClass != null ? studentClass.StudyYear : 2019;
            return studentDto;
        }
    }
}
