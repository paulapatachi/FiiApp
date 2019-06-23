using AutoMapper;
using FiiApp.Data.Entities;
using FiiApp.Services.DTOs;

namespace FiiApp.Services.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
                .ForMember(x => x.Citizenship, opt => opt.MapFrom(src => src.Citizenship.Name))
                .ForMember(x => x.Class, opt => opt.Ignore())
                .ForMember(x => x.StudyYear, opt => opt.Ignore());

            CreateMap<FinalGrade, FinalGradeDto>()
                .ForMember(x => x.Semester, opt => opt.MapFrom(src => src.Course.Semester))
                .ForMember(x => x.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(x => x.Credits, opt => opt.MapFrom(src => src.Course.NumberOfCredits));

            CreateMap<Grade, GradeDto>()
                .ForMember(x => x.YourScore, opt => opt.MapFrom(src => src.Score))
                .ForMember(x => x.MaxScore, opt => opt.MapFrom(src => src.Evaluation.MaxScore))
                .ForMember(x => x.Grade, opt => opt.MapFrom(src => src.GradeValue))
                .ForMember(x => x.TeacherName, opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                .ForMember(x => x.EvaluationName, opt => opt.MapFrom(src => src.Evaluation.Name))
                .ForMember(x => x.EvaluationType, opt => opt.MapFrom(src => src.Evaluation.Type.Name));
                
        }
    }
}
