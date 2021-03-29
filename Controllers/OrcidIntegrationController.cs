using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CapstoneProject.APIModels;
using CapstoneProject.Models;
using CapstoneProject.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapstoneProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OrcidIntegrationController : ControllerBase
    {

        private readonly EmployeesService _employeeService;

        public OrcidIntegrationController(EmployeesService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<OrcidIntegrationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Development is in progress" };
        }

        // GET api/<OrcidIntegrationController>/5
        [HttpGet("{orcid}")]
        public string Get(int orcid)
        {
            return "value";
        }

        [HttpPost]
        public ActionResult<Employees> Login([FromBody] LoginDTO value)
        {
            Employees obj = _employeeService.ValidateLoginCredentials(value.orcId, value.password);
            if (obj != null)
            {
                return obj;
            }
            return NotFound();
        }

        // POST api/<OrcidIntegrationController>
        [HttpPost]
        [Route("accesstoken")]
        public async Task<IActionResult> Post([FromBody] CodeDTO value)
        {
            HttpResponseMessage httpResponseMessage = await _employeeService.GetEmployeeAccessTokenFromApi(value.accessToken);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OAuthTokenDTO oAuthTokenDTO = JsonConvert.DeserializeObject<OAuthTokenDTO>(httpResponseMessage.Content.ReadAsStringAsync().Result);
                Employees employeeObj = _employeeService.GetByOrcid(oAuthTokenDTO.orcid);
                if (employeeObj == null)
                {
                    //var obj = _employeeService.Create("shujaat Siddiqui", "0000-0002-5807-5617", "admin123", "f1c0d2ec-6693-4739-bc10-ce02fb784884");
                    var obj = _employeeService.Create(oAuthTokenDTO.name, oAuthTokenDTO.orcid, "admin123", oAuthTokenDTO.access_token);
                    return CreatedAtAction("accesstoken", new { orcid = obj.OrcId, password = obj.Password });
                }
                else
                {
                    employeeObj.AccessToken = oAuthTokenDTO.access_token;
                    _employeeService.Update(employeeObj);
                    return Content(JsonConvert.SerializeObject(employeeObj));
                }
            }
            else
            {
                return Content(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }
        }

        // PUT api/<OrcidIntegrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrcidIntegrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class LoginDTO
    {
        public string orcId { get; set; }
        public string password { get; set; }
    }

    public class CodeDTO
    {
        public string accessToken { get; set; }
    }
}
