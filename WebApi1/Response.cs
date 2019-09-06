


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1
{
    public class Response
    {
        //[HttpGet]
        //public ActionResult<YOUROBJECT> Get()
        //{
        //    return StatusCode(304, YOUROBJECT); 
        //}

        public Object data;
        public string message;
        // success 
        // not found
        // invalid request
        public int statusCode;
       
    }
}