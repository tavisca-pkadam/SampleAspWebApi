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
            ViewBag.Response = userService.GetList();
            return ViewBag;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
           ViewBag.Response = userService.GetSingle(id);
            
           return StatusCode(304, ViewBag);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult Post(UserModel newUser)
        {
            ViewBag.Response = userService.Create(newUser);
            return ViewBag;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserModel userDataUpdate)
        {
            ViewBag.Response = userService.Update(id, userDataUpdate);
            return ViewBag;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
             ViewBag.Response = userService.Delete(id);
            return ViewBag;
        }
    }
}
