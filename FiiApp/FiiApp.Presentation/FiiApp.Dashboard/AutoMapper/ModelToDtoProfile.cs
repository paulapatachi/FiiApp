using AutoMapper;
using FiiApp.Dashboard.Helpers;
using FiiApp.Dashboard.Models;
using FiiApp.Services.DTOs;
using PFPrediction.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.AutoMapper
{
  public class ModelToDtoProfile: Profile
  {
    public ModelToDtoProfile()
    {
      CreateMap<UserDto, UserModel>()
        .ForMember(x => x.Token, opts => opts.Ignore());

      CreateMap<StudentDto, StudentModel>()
        .ForMember(x => x.DateOfBirth, opts => opts.MapFrom(src => HelperMethods.DateTimeToString(src.DateOfBirth, "dd'/'MM'/'yyyy")));

      CreateMap<FinalGradeDto, FinalGradeModel>()
        .ForMember(x => x.Grade, opt => opt.MapFrom(src => HelperMethods.DecimalToString(src.Grade)))
        .ForMember(x => x.Credits, opt => opt.MapFrom(src => HelperMethods.DecimalToString(src.Credits)))
        .ForMember(x => x.Date, opt => opt.MapFrom(src => HelperMethods.DateTimeToString(src.Date, "dd'.'MM'.'yyyy")));

      CreateMap<GradeDto, GradeModel>()
        //.ForMember(x => x.MaxScore, opt => opt.MapFrom(src => HelperMethods.DecimalToString(src.MaxScore)))
        //.ForMember(x => x.YourScore, opt => opt.MapFrom(src => HelperMethods.DecimalToString(src.YourScore)))
        //.ForMember(x => x.Grade, opt => opt.MapFrom(src => HelperMethods.DecimalToString(src.Grade)))
        .ForMember(x => x.EvalDate, opt => opt.MapFrom(src => HelperMethods.DateTimeToString(src.EvalDate, "dd'.'MM'.'yyyy")));

      CreateMap<GradesMeanDto, GradesMeanModel>()
        .ForMember(x => x.Average, opt => opt.MapFrom(src => HelperMethods.TruncateDecimal(src.Average)))
        .ForMember(x => x.AverageYear, opt => opt.MapFrom(src => HelperMethods.TruncateDecimal(src.AverageYear)))
        .ForMember(x => x.ECTSMean, opt => opt.MapFrom(src => HelperMethods.TruncateDecimal(src.ECTSMean)))
        .ForMember(x => x.ECTSMeanYear, opt => opt.MapFrom(src => HelperMethods.TruncateDecimal(src.ECTSMeanYear)));

      CreateMap<ModelInputModel, ModelInput>()
        .ForMember(x => x.PF, opt => opt.Ignore());
    }
  }
}
