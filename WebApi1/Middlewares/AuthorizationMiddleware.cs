using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WebApi1
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StringValues TokenValue;
            var authorizationExists = httpContext.Request.Headers.TryGetValue("Authorization", out TokenValue);
            if (authorizationExists)
            {
                if (!TokenValue.ToString().Equals("101101"))
                {
                    await httpContext.Response.WriteAsync("Authorization token incorrect");
                }

            }
            else
            {
                await httpContext.Response.WriteAsync("Authorization token not found");
            }

            //read the request body

            //serialize the json body to input model

            //validations
            //return response - id is null

            //other validations

            await _next(httpContext);

        }
    }
}