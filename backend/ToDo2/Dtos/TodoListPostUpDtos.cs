using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDo2.Models;
using ToDo2.ValidationAttributes;
using System.Linq;
using ToDo2.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo2.Utils;


namespace ToDo2.Dtos
{
    //[StartEnd]
    //[Test("123")]
    public class TodoListPostUpDtos
    {
        // adding this like validation attribute
        [ModelBinder(BinderType = typeof(FormDataJsonBinder))] 
        public TodoListPostDtos TodoList {  get; set; }

        public IFormFileCollection files {  get; set; }
    }

}
