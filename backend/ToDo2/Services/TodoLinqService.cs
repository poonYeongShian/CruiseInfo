using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDo2.Dtos;
using ToDo2.Interfaces;
using ToDo2.Models;
using ToDo2.Parameters;

namespace ToDo2.Services
{
    public class TodoLinqService: ITodoListService
    {
        private readonly TodoContext _todoContext;

        public TodoLinqService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public List<TodoListSelectDtos> GetData(TodoSelectParameter value)
        {
            /*
             * Get all data
             * **/
            var result = _todoContext.TodoLists
                .Include(a => a.InsertEmployee)
                .Include(a => a.UpdateEmployee)
                .Include(a => a.UploadFiles)
                .Select(a => a);

            if (!string.IsNullOrWhiteSpace(value.name))
            {
                result = result.Where(a => a.Name.Contains(value.name));
            }

            if (value.enable != null)
            {
                result = result.Where(a => a.Enable == value.enable);
            }

            if (value.InsertTime != null)
            {
                result = result.Where(a => a.InsertTime.Date == value.InsertTime);
            }

            if (value.minOrder != null && value.maxOrder != null)
            {
                result = result.Where(a => a.Orders >= value.minOrder && a.Orders <= value.maxOrder);
            }

            return result.ToList().Select(a => ItemToDto(a)).ToList();
        }

        private static TodoListSelectDtos ItemToDto(TodoList a)
        {
            List<UploadFileDtos> updto = new List<UploadFileDtos>();

            foreach (var temp in a.UploadFiles)
            {
                UploadFileDtos up = new UploadFileDtos
                {
                    Name = temp.Name,
                    Src = temp.Src,
                    TodoId = temp.TodoId,
                    UploadFileId = temp.UploadFileId
                };
                updto.Add(up);
            }
            return new TodoListSelectDtos
            {
                Enable = a.Enable,
                InsertEmployeeName = a.InsertEmployee?.Name,
                InsertTime = a.InsertTime,
                Name = a.Name,
                Orders = a.Orders,
                TodoId = a.TodoId,
                UpdateEmployeeName = a.UpdateEmployee?.Name,
                UpdateTime = a.UpdateTime,
                UploadFiles = updto
            };
        }
    }
}
