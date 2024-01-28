using ToDo2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDo2.Dtos;


namespace ToDo2.ValidationAttributes
{
    public class StartEndAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var st = (TodoListPostDtos)value;

            if (st.StartTime >= st.EndTime)
            {
                return new ValidationResult("Start time cannot larger than End time", new string[] {"msg"});
            }

            return ValidationResult.Success;
        }
    }
}
