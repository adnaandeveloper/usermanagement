using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dot_net_core.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_dot_net_core.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: api/values
        [HttpGet("get-public")]
        public IActionResult GetPublicData()
        {
            return Ok("Public data");
        }

      
        [HttpGet("get-user-role")]
        [Authorize (Roles = StaticUserRoles.USER)]
        public IActionResult GetUserData()
        {
            return Ok("user role  data");
        }

      
        [HttpGet("get-admin-role")]
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        public IActionResult GetManagerData() 
        {
            return Ok("Admin role  data");
        }

        
        [HttpGet("get-Admin-role")]
        [Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAdminData()
        {
            return Ok("Admin role  data");
        }
      
        [HttpGet("get-Owner-role")]
        [Authorize(Roles = StaticUserRoles.OWNER)]
        public IActionResult GetOwnerData()
        {
            return Ok("Owner role  data");
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

