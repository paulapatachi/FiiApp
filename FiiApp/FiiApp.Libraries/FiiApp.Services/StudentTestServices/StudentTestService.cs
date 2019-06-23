using AutoMapper;
using FiiApp.Data.Entities;
using FiiApp.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FiiApp.Services.StudentTestServices
{
    public class StudentTestService : IStudentTestService
    {
        private readonly IRepository<StudentTest> studentsRepository;
        private readonly IMapper mapper;

        public StudentTestService(IRepository<StudentTest> studentsRepository,
                                  IMapper mapper)
        {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
        }

        public IEnumerable<StudentTestDto> GetAllStudents()
        {
            var students = studentsRepository.Query().Select(x => mapper.Map<StudentTestDto>(x)).ToList();
            return students;
        }
    }
}
