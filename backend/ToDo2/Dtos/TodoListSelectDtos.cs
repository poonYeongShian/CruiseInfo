using System;
using System.Collections.Generic;
using ToDo2.Models;

namespace ToDo2.Dtos
{
    public class TodoListSelectDtos
    {
        public Guid TodoId { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Enable { get; set; }
        public int Orders { get; set; }
        public string InsertEmployeeName { get; set; }
        public string UpdateEmployeeName { get; set; }
        public ICollection<UploadFileDtos> UploadFiles { get; set; }
    }
}
