using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using ToDo2.Dtos;

namespace ToDo2.Filters
{
    public class TodoAuthorizationFilter :Attribute, IAuthorizationFilter
    {
        /*
         * Demo Authorization Filter
         * **/
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool tokenFlag = context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues outValue);

            // Check whether the API contains [AllowAnonymousAttribute] tag
            var ignore = (from a in context.ActionDescriptor.EndpointMetadata
                          where a.GetType() == typeof(AllowAnonymousAttribute)
                          select a).FirstOrDefault();


            // do filter if we are not calling login api
            if (ignore == null)
            {
                if (tokenFlag)
                            {
                                if (outValue != "123")
                                {
                                    //context result, it is the return result, other filter won't be execute
                                    context.Result = new JsonResult(new ReturnJson()
                                    {
                                        Data = "test1",
                                        HttpCode = 401,
                                        ErrorMessage = "Not Sign In Yet ;-;"
                                    });
                                }
                            }
                            else
                            {
                                context.Result = new JsonResult(new ReturnJson()
                                {
                                    Data = "test1",
                                    HttpCode = 401,
                                    ErrorMessage = "Not Sign In Yet ;-;"
                                });
                            }
            }


            
        }
    }
}
