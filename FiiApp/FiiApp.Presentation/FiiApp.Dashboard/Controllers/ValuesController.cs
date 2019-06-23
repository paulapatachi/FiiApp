using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiiApp.Dashboard.Helpers;
using FiiApp.Services.FacultyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiiApp.Dashboard.Controllers
{
  [Authorize(Roles = "Student")]
  [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

    private readonly IFacultyService facultyService;

    public ValuesController(IFacultyService facultyService)
    {
      this.facultyService = facultyService;
    }

    [HttpGet]
    public string GetTestValues()
    {
      var xx = HeaderValueReader.GetUserId(Request);
      var cc = HeaderValueReader.GetUserRole(Request);
      var text = facultyService.Ceva();
      return text + "          Ana are mere" + xx + cc;
    }





        //// GET: api/Values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Values/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
