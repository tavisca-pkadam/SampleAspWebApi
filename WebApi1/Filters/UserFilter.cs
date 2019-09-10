using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Filters
{
    public class UserFilter
    {
    }

    public class MySampleActionFilterAttribute : ActionFilterAttribute
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MySampleActionFilterAttribute));

        public override void  OnActionExecuting(ActionExecutingContext context)
        {
            log.Info("OnActionExecuting");
            // Do something before the action executes.
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
