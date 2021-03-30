using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthTest.API.Services;
using CapstoneProject.Models;
using CapstoneProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AuthorizeController : Controller
    {

        private readonly EmployeesService _employeeService;
        private readonly JwtService _jwtService;

        public AuthorizeController(EmployeesService employeeService, JwtService jwtService)
        {
            _employeeService = employeeService;
            _jwtService = jwtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] LoginDTO value)
        {
            EmployeeDetails obj = _employeeService.ValidateLoginCredentials(value.orcId, value.password);
            if (obj != null)
            {
                return _jwtService.GenerateSecurityToken(obj.AccessToken, obj.OrcId);
            }
            return BadRequest("Invalid Username or Password");
        }
    }
}
