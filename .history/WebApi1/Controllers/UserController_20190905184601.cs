using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private static UserService userService = new UserService();

        public UserController()
        {
           
        }

        // GET: api/User
        [HttpGet]
        public ActionResult Get()
        {
            ViewBag.Data = 
            return null;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<UserModel> Get(int id)
        {
            return null;

        }

        // POST: api/User
        [HttpPost]
        public void Post(UserModel newUser)
        {
            if (ModelState.IsValid)
            {

            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserModel updateValue)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
