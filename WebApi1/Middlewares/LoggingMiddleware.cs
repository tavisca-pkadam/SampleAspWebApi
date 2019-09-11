using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi1
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoggingMiddleware));

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var authorization = httpContext.Request.Headers.ContainsKey("Authorization");
            
            log.Info($"Logging Middleware {authorization}");
            //read the request body

            //serialize the json body to input model

            //validations
            //return response - id is null

            //other validations

            await _next(httpContext);

        }
    }
}