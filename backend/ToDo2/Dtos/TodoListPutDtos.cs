using System;
using System.Collections.Generic;
using ToDo2.Abstracts;
using ToDo2.Models;
using ToDo2.ValidationAttributes;

namespace ToDo2.Dtos
{
    public class TodoListPutDtos : TodoListEditDtoAbstract
    {
        // put will have primary key
        public Guid TodoId { get; set; }
     
    }
}
