using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FiiApp.Dashboard.Helpers;
using FiiApp.Dashboard.Models;
using FiiApp.Services.DTOs;
using FiiApp.Services.SendGridEmailServices;
using FiiApp.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiiApp.Dashboard.Controllers
{
  [Authorize()]
  [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    private readonly IUserService userService;
    private readonly IEmailService emailService;
    private readonly IMapper mapper;

    public UserController(IUserService userService, IEmailService emailService, IMapper mapper)
    {
      this.userService = userService;
      this.emailService = emailService;
      this.mapper = mapper;
    }


    [HttpPost("SendEmail")]
    public IActionResult SendEmail([FromBody]FiiAppEmailModel emailModel)
    {
      emailModel.FromEmail = HeaderValueReader.GetUserEmail(Request);
      emailModel.FromName = HeaderValueReader.GetUserFullName(Request);
      try
      {
        var emailDto = mapper.Map<FiiAppEmailDto>(emailModel);
        emailService.SendEmailMessage(emailDto);
        return Ok(new { message = "Message sent."});
      }
      catch (Exception ex)
      {
        Trace.WriteLine("There is a problem at email sending.\n" + ex.Message);
        return BadRequest(new { message = "There is a problem at email sending." });
      }
    }

    [HttpGet("GetUserInfo")]
    public IActionResult GetUserInfo()
    {
      var userId = 0 ;
      if(Int32.TryParse(HeaderValueReader.GetUserId(Request), out userId))
      {
        var userInfo = userService.GetStudentInformation(userId);
        return Ok(mapper.Map<StudentModel>(userInfo));
      }
      return BadRequest(new { message = "Something went wrong when trying to get user info" });
    }
  }
}
