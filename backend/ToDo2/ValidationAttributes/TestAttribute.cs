using ToDo2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDo2.Dtos;


namespace ToDo2.ValidationAttributes
{
    public class TestAttribute : ValidationAttribute
    {
        private string _tvalue;
        public TestAttribute(string tvalue="Default msg heheh") {
            _tvalue = tvalue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var st = (TodoListPostDtos)value;

      
            return new ValidationResult(_tvalue, new string[] { "_tvalue" });
            
        }
    }
}
