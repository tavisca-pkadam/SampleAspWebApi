using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1 {
    public class Response {
        public Object data;
        public List<string> message;
        public int statusCode;

        public Response()
        {
            message = new List<string>();
        }
    }
}