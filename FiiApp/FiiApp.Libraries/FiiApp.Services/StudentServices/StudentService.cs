using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FiiApp.Data.Entities;
using FiiApp.Data.Infrastructure;
using FiiApp.Services.DTOs;

namespace FiiApp.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public StudentDto GetStudentByUserId(int userId)
        {
            var student = studentRepository.Query().FirstOrDefault(x => x.UserId.HasValue && x.UserId == userId);
            return mapper.Map<StudentDto>(student);
        }
    }
}
