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
using Microsoft.AspNetCore.Http;

namespace ToDo2.Services
{
    public class TodoListService
    {

        private readonly TodoContext _todoContext;

        // access login info
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TodoListService(TodoContext todoContext, IHttpContextAccessor httpContextAccessor)
        {
            _todoContext = todoContext;
            _httpContextAccessor = httpContextAccessor;
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

        public TodoList AddNewData(TodoListPostDtos value)
        {
            //Get user login info
            //var Claim = _httpContextAccessor.HttpContext.User.Claims.ToList();

            //var employeeid = Claim.Where(a => a.Type == "EmployeeId").First().Value;

            TodoList insert = new TodoList
            {
                //Auto generate by system
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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

            _todoContext.SaveChanges();

            return insert;
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
