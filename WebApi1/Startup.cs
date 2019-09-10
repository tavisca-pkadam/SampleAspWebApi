using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using WebApi1.Filters;

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

    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoggingMiddleware));

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

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(MySampleActionFilter));         // By type
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}