using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace ToDo2.Filters
{
    public class TodoActionFilter : Attribute, IActionFilter
    {
        /*
         * Demo: Action Filter
         * We want to use this to create log, e.g what API did the user call, when it happen.
         * **/

        private readonly IWebHostEnvironment _env;

        public TodoActionFilter(IWebHostEnvironment env) {
            _env = env;
        }

        // Happen after running controller
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string rootRoot = _env.ContentRootPath + @"\Log\" + "\\";

            if (!Directory.Exists(rootRoot))
            {
                // Check whether path exist, if not create one
                Directory.CreateDirectory(rootRoot);
            }
            var employeeid = context.HttpContext.User.FindFirst("EmployeeId");
            var path = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;
            string text = "结束： " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " path:" + path
                + " method:" + method + " " + employeeid + "\n";
            File.AppendAllText(rootRoot + DateTime.Now.ToString("yyyyMMdd") + ".txt", text);
        }

        // Happen before running controller
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string rootRoot = _env.ContentRootPath + @"\Log\" + "\\";

            if (!Directory.Exists(rootRoot))
            {
                // Check whether path exist, if not create one
                Directory.CreateDirectory(rootRoot);
            }

            var employeeid = context.HttpContext.User.FindFirst("EmployeeId");
            var path = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;
            string text = "开始： " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " path:" + path 
                + " method:" + method + " " + employeeid + "\n";
            File.AppendAllText(rootRoot + DateTime.Now.ToString("yyyyMMdd") + ".txt", text);
        }
    }
}
