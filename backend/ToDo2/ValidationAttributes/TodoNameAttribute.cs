using ToDo2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDo2.Dtos;


namespace ToDo2.ValidationAttributes
{
    public class TodoNameAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TodoContext _todoContext = (TodoContext)validationContext.GetService(typeof(TodoContext));

            var name = (string)value;

            var findName = from a in _todoContext.TodoLists
                           where a.Name == name
                           select a;

            // Check which class is calling it
            var dto = validationContext.ObjectInstance;
            if(dto.GetType() == typeof(TodoListPutDtos))
            {
                var dtoUpdate = (TodoListPutDtos)dto;
                findName = findName.Where(a => a.TodoId != dtoUpdate.TodoId);
            }


            if (findName.FirstOrDefault()!=null) 
            {
                return new ValidationResult("There is an existing to do item in database");
            }

            return ValidationResult.Success;
        }
    }
}
