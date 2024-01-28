using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using ToDo2.Dtos;
using ToDo2.Models;
using ToDo2.Parameters;
using ToDo2.ValidationAttributes;
using ToDo2.Abstracts;
using System;
using System.Threading.Tasks;

namespace ToDo2.Services
{
    public class TodoAsyncService
    {
        /*
         * Demo async await for GET and POST
         * **/

        private readonly TodoContext _todoContext;

        public TodoAsyncService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<TodoListSelectDtos>> GetData(TodoSelectParameter value)
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

            var temp = await result.ToListAsync();

            return temp.Select(a => ItemToDto(a)).ToList();
        }

        public TodoListSelectDtos GetOneData(Guid todoId)
        {
            /*
             * Get data by ID
             * **/
            var result = (from a in _todoContext.TodoLists
                          where a.TodoId == todoId
                          select a)
                .Include(a => a.UpdateEmployee)
                .Include(a => a.InsertEmployee)
                .Include(a => a.UploadFiles)
                .SingleOrDefault();

            if (result != null)
            {
                return ItemToDto(result);
            }
            return null;

        }

        public async Task AddNewData(TodoListPostDtos value)
        {
            TodoList insert = new TodoList
            {
                //Auto generate by system
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            };
            _todoContext.TodoLists.Add(insert).CurrentValues.SetValues(value);
            _todoContext.SaveChanges();

            foreach (var temp in value.UploadFiles)
            {
                _todoContext.UploadFiles.Add(new UploadFile()
                {
                    TodoId = insert.TodoId
                }).CurrentValues.SetValues(temp);
            }

            await _todoContext.SaveChangesAsync();
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
