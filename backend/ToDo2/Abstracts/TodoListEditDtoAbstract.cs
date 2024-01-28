using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using ToDo2.Dtos;
using ToDo2.Models;
using System.Linq;

namespace ToDo2.Abstracts
{
    public abstract class TodoListEditDtoAbstract: IValidatableObject
    {
        //post no primary key
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int Orders { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<UploadFilePostDtos> UploadFiles { get; set; }

        public TodoListEditDtoAbstract()
        {
            UploadFiles = new List<UploadFilePostDtos>();
        }

        // Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            TodoContext _todoContext = (TodoContext)validationContext.GetService(typeof(TodoContext));



            var findName = from a in _todoContext.TodoLists
                           where a.Name == Name
                           select a;

            // Check which class is calling it
            // var dto = validationContext.ObjectInstance; // no needed

            if (this.GetType() == typeof(TodoListPutDtos))
            {
                var dtoUpdate = (TodoListPutDtos)this;
                findName = findName.Where(a => a.TodoId != dtoUpdate.TodoId);
            }


            if (findName.FirstOrDefault() != null)
            {
                // yield is use for IEnumerable, garther as array and output
                yield return new ValidationResult("There is an existing to do item in database", new string[] { "name" });
            }

            if (StartTime >= EndTime)
            {
                yield return new ValidationResult("Start time cannot larger than end time", new string[] { "time" });
            }

        }
    }
}
