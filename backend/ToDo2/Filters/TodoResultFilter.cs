using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using ToDo2.Dtos;

namespace ToDo2.Filters
{
    public class TodoResultFilter : Attribute, IResultFilter
    {
        /*
         * Demo Result Filter: This is where we do result post processing
         *                     Wrap the result inside "DATA" : []
         * **/
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var contextResult = context.Result as ObjectResult;

            if(context.ModelState.IsValid) // check whether the all authentication valid
            {
                context.Result = new JsonResult(new ReturnJson()
                            {
                                Data = contextResult.Value
                            });
            }
            else
            {
                context.Result = new JsonResult(new ReturnJson()
                            {
                                Error = contextResult.Value
                            });
            }

            
        }
    }
}
