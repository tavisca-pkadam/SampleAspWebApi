using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;
using WebApi1.Services;
using WebApi1.Filters;

namespace WebApi1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UserController : Controller {

        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserController));


        private static IService userService;

        public UserController (IService service) {
            userService = service;
        }

        // GET: api/User
        [HttpGet]
        [MySampleActionFilterAttribute]
        public ActionResult Get () {
            log.Info("Get() Method -> " + this.Request.ToString());

            ViewBag.Response = userService.GetList ();
            return StatusCode (ViewBag.Response.statusCode, ViewBag);
        }

        // GET: api/User/5
        [HttpGet ("{id}", Name = "Get")]
        public ActionResult Get (int id) {
            log.Info("Get(id) Method -> " + this.Request.ToString());

            ViewBag.Response = userService.GetSingle (id);
            return StatusCode (ViewBag.Response.statusCode, ViewBag);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult Post (UserModel newUser) {
            log.Info("Post() Method -> " + this.Request.ToString());

            ViewBag.Response = userService.Create (newUser);
            return StatusCode (ViewBag.Response.statusCode, ViewBag);
        }

        // PUT: api/User/5
        [HttpPut ("{id}")]
        public ActionResult Put (int id, [FromBody] UserModel userDataUpdate) {
            log.Info("Put() Method -> " + this.Request.ToString());

            ViewBag.Response = userService.Update (id, userDataUpdate);
            return StatusCode (ViewBag.Response.statusCode, ViewBag);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete ("{id}")]
        public ActionResult Delete (int id) {
            log.Info("Delete() Method -> " + this.Request.ToString());

            ViewBag.Response = userService.Delete (id);
            return StatusCode (ViewBag.Response.statusCode, ViewBag);
        }
    }
}