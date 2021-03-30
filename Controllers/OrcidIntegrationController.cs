using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using CapstoneProject.APIModels;
using CapstoneProject.Models;
using CapstoneProject.Services;
using Microsoft.AspNetCore.Authorization;
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

        // GET api/<OrcidIntegrationController>/5
        [HttpGet]
        [Route("{orcid}")]
        public async Task<ActionResult> Get(string orcid)
        {
            EmployeeDetails employeeDetails = _employeeService.GetByOrcid(orcid);
            if (employeeDetails != null && employeeDetails.Details == null)
            {
                HttpResponseMessage httpResponseMessage = await _employeeService.GetEmployeeDetailsFromAPI(employeeDetails.AccessToken);
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(httpResponseMessage.Content.ReadAsStringAsync().Result);
                    string json = JsonConvert.SerializeXmlNode(doc);
                    Root Root = JsonConvert.DeserializeObject<Root>(json);
                    employeeDetails.Details = Root;
                    _employeeService.UpdateEmployeeDetails(employeeDetails);
                    return Ok(Root);
                }
            }
            else if (employeeDetails != null && employeeDetails.Details != null)
            {
                return Ok(employeeDetails.Details);
            }
            return BadRequest("Invalid ORCID");
        }

        [HttpGet]
        [Route("FetchDetail/{orcid}")]
        public async Task<ActionResult> FetchDetail(string orcid)
        {
            EmployeeDetails employeeDetails = _employeeService.GetByOrcid(orcid);
            if (employeeDetails != null)
            {
                HttpResponseMessage httpResponseMessage = await _employeeService.GetEmployeeDetailsFromAPI(employeeDetails.AccessToken);
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(httpResponseMessage.Content.ReadAsStringAsync().Result);
                    string json = JsonConvert.SerializeXmlNode(doc);
                    Root Root = JsonConvert.DeserializeObject<Root>(json);
                    employeeDetails.Details = Root;
                    _employeeService.UpdateEmployeeDetails(employeeDetails);
                    return Ok(Root);
                }
            }
            return BadRequest("Invalid ORCID");
        }

        // POST api/<OrcidIntegrationController>
        // Register API
        [HttpPost]
        [Route("accesstoken")]
        public async Task<IActionResult> Post([FromBody] CodeDTO value)
        {
            HttpResponseMessage httpResponseMessage = await _employeeService.GetEmployeeAccessTokenFromApi(value.code);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OAuthTokenDTO oAuthTokenDTO = JsonConvert.DeserializeObject<OAuthTokenDTO>(httpResponseMessage.Content.ReadAsStringAsync().Result);
                EmployeeDetails employeeObj = _employeeService.GetByOrcid(oAuthTokenDTO.orcid);
                if (employeeObj == null)
                {
                    EmployeeDetails employeeDetails = new EmployeeDetails()
                    { AccessToken = oAuthTokenDTO.name, Name = oAuthTokenDTO.orcid, OrcId = oAuthTokenDTO.orcid, Password = "admin123" };
                    return CreatedAtAction("accesstoken", new { orcid = employeeDetails.OrcId, password = employeeDetails.Password });
                }
                else
                {
                    employeeObj.AccessToken = oAuthTokenDTO.access_token;
                    _employeeService.UpdateAccessToken(employeeObj);
                    return Content(JsonConvert.SerializeObject(employeeObj.AccessToken));
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
        public string code { get; set; }
    }
}
