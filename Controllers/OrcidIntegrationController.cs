using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapstoneProject.Controllers
{
    public class AccessTokenDTO
    {
        public string accesstoken { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class OrcidIntegrationController : ControllerBase
    {
        // GET: api/<OrcidIntegrationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Development is in progress" };
        }

        // GET api/<OrcidIntegrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrcidIntegrationController>
        [HttpPost]
        [Route("accesstoken")]
        public IActionResult Post([FromBody] AccessTokenDTO value)
        {
            return CreatedAtAction("accesstoken", value);
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
}
