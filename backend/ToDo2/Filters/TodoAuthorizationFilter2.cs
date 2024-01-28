using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using ToDo2.Dtos;
using ToDo2.Models;

namespace ToDo2.Filters
{
    public class TodoAuthorizationFilter2 :Attribute, IAuthorizationFilter
    {
        /*
         * Demo Authorization Filter 2
         * **/
        public string Roles = "";
        public TodoAuthorizationFilter2()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            TodoContext _todoContext = (TodoContext)context.HttpContext.RequestServices.GetService(typeof(TodoContext));

            // check whether the role pass in exist in db
            var role = (from a in _todoContext.Roles
                        where a.Name == Roles
                        select a).FirstOrDefault();

            //Do user role checking
            if (role == null)
            {
                //no role, put message
                context.Result = new JsonResult(new ReturnJson()
                            {
                                Data = Roles,
                                HttpCode = 401,
                                ErrorMessage = "Not Sign In Yet ;-;"
                            });
            }

            

        }
        
    }
}
