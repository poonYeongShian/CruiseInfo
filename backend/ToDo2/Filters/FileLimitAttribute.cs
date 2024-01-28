using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using ToDo2.Dtos;

namespace ToDo2.Filters
{
    public class FileLimitAttribute : Attribute, IResourceFilter
    {
        /*
         * Demo resource filter
         * **/

        public long Size = 100000;  // Default size

        // This will go next in the lifecycle
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        // This will run first in the lifecycle
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // multiple files
            var files = context.HttpContext.Request.Form.Files;

            foreach (var file in files) { 
                if(file.Length > (1024 * 1024) * Size) // file greater than 1MB
                {
                    //larger than 1MB, put message
                    context.Result = new JsonResult(new ReturnJson()
                    {
                        Data = "test1",
                        HttpCode = 401,
                        ErrorMessage = "File shouldn't larger than 1MB ;-;"
                    });
                }

                if(Path.GetExtension(file.FileName) != ".mp4") // file type not txt
                {
                    context.Result = new JsonResult(new ReturnJson()
                    {
                        Data = "test1",
                        HttpCode = 401,
                        ErrorMessage = "Only MP4 file allow ;.;"
                    });
                }
            }
        }
    }
}
