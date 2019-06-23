using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FiiApp.Dashboard.Models;
using FiiApp.Services.Helpers;
using FiiApp.Services.StudentServices;
using FiiApp.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FiiApp.Dashboard.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IUserService userService;
    private readonly IStudentService studentService;
    private readonly IConfiguration configuration;
    private readonly IMapper mapper;

    public AuthController(IUserService userService, IStudentService studentService, IConfiguration configuration, IMapper mapper)
    {
      this.userService = userService;
      this.studentService = studentService;
      this.configuration = configuration;
      this.mapper = mapper;
    }

    [HttpPost("GetToken")]
    public IActionResult GetToken(string username, string password)
    {
      var user = userService.AuthenticateUser(username, password);

      if (user is null)
        return BadRequest(new { message = "The username or password is incorrect" });
      
      var securityKey = configuration["JWTDetails:SecurityKey"];
      var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
      var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

      var claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Role, user.Role));
      claims.Add(new Claim("UserId", user.Id.ToString()));

      if (user.Role == UserRoles.Student)
      {
        var student = studentService.GetStudentByUserId(user.Id);
        claims.Add(new Claim("UserFullName", $"{student.FirstName} {student.LastName}"));
        claims.Add(new Claim("UserEmail", student.Email));
      }

      //create token
      var jwttoken = new JwtSecurityToken(
              issuer: configuration["JWTDetails:Issuer"],
              audience: configuration["JWTDetails:Audience"],
              expires: DateTime.Now.AddHours(1),
              signingCredentials: signingCredentials,
              claims: claims
          );
      var token = new JwtSecurityTokenHandler().WriteToken(jwttoken);

      var loggedUser = mapper.Map<UserModel>(user);
      loggedUser.Token = token;
      return Ok(loggedUser);
    }

    [HttpPost("RegisterNewUser")]
    public IActionResult RegisterNewUser(string registrationNumber, string email, string password)
    {
      // verify if student with credentials exists in database
      var studentExists = userService.VerifyIfStudentExists(registrationNumber, email);
      if (!studentExists)
        return BadRequest(new { message = "The student with the entered registration number and webmail address does not exist" });

      // verify if student has associated an user id
      var userExists = userService.VerifyIfStudentHasAccount(registrationNumber, email);
      if (userExists)
        return BadRequest(new { message = "The student with the entered registration number and webmail address already has an account" });

      // register new user
      var username = userService.RegisterNewUser(registrationNumber, email, password);
      return GetToken(username, password);
    }
  }
}
