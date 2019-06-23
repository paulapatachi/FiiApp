using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Helpers
{
  public static class HeaderValueReader
  {
    public static string  GetUserId(HttpRequest request)
    {
      return request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
    }

    public static string GetUserFullName(HttpRequest request)
    {
      return request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserFullName")?.Value;
    }

    public static string GetUserEmail(HttpRequest request)
    {
      return request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserEmail")?.Value;
    }

    public static string GetUserRole(HttpRequest request)
    {
      return request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
    }
  }
}
