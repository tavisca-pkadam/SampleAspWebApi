


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebApi1
{
    public class Response
    {
        [HttpGet]
        public ActionResult<YOUROBJECT> Get()
        {
            return StatusCode(304, YOUROBJECT); 
        }
    }
}