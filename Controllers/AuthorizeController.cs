using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Models;
using CapstoneProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AuthorizeController : Controller
    {

        private readonly EmployeesService _employeeService;

        public AuthorizeController(EmployeesService employeeService)
        {
            _employeeService = employeeService;
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
                return obj.AccessToken;
            }
            return BadRequest("Invalid Username or Password");
        }
    }
}
