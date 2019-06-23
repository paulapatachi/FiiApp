using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECTSPrediction.Model.DataModels;
using PFPrediction.Model.DataModels;
using FiiApp.Dashboard.Models;
using FiiApp.Services.MLServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiiApp.Dashboard.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
    [ApiController]
    public class MLAndStatisticsController : ControllerBase
    {
        private readonly IMLService mlService;
    private readonly IMapper mapper;

    public MLAndStatisticsController(IMLService mlService, IMapper mapper)
    {
      this.mlService = mlService;
      this.mapper = mapper;
    }

    [HttpGet("ECTSPrediction")]
    public IActionResult GetECTSPredictionGrade([FromQuery]float PFScore)
    {
      var pred = mlService.GetECTSPredictionForStudent(PFScore);
      return Ok(pred);
    }

    [HttpPost("PFPrediction")]
    public IActionResult GetPFPredictionGrade([FromBody]ModelInputModel input)
    {
      var data = mapper.Map<PFPrediction.Model.DataModels.ModelInput>(input);
      var pred = mlService.GetPFPredictionForStudent(data);
      return Ok(pred);
    }

    [HttpGet("Statistics")]
    public IActionResult GetMathStatisticsData()
    {
      mlService.GetGenderStatistics();
      return Ok();
    }

    [HttpGet("AttendanceStatistics")]
    public JsonResult GetAttendanceStatistics()
    {
      var result = mlService.GetAttendanceStatistics();
      return new JsonResult(result);
    }

    [HttpGet("GenderStatistics")]
    public JsonResult GetGenderStatistics()
    {
      var result = mlService.GetGenderStatistics();
      return new JsonResult(result);
    }

    [HttpGet("FinalScoreStatisticsByYear")]
    public JsonResult GetFinalScoreStatisticsByYear()
    {
      var result = mlService.GetFinalScoreStatisticsByYear();
      return new JsonResult(result);
    }

    [HttpGet("FinalScoreStatisticsByClass")]
    public JsonResult GetFinalScoreStatisticsByClass()
    {
      var result = mlService.GetFinalScoreStatisticsByClass();
      return new JsonResult(result);
    }

    [HttpGet("FinalScoreStatisticsByGender")]
    public JsonResult GetFinalScoreStatisticsByGender()
    {
      var result = mlService.GetFinalScoreStatisticsByGender();
      return new JsonResult(result);
    }

    [HttpGet("SeminarActivityStatistics")]
    public JsonResult GetSeminarActivityStatistics()
    {
      var result = mlService.GetSeminarActivityStatistics();
      return new JsonResult(result);
    }

    [HttpGet("GNumberOfPassedStudents")]
    public JsonResult GetNumberOfPassedStudents()
    {
      var result = mlService.GetNumberOfPassedStudents();
      return new JsonResult(result);
    }

  }
}
