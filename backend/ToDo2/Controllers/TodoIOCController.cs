using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo2.Dtos;
using ToDo2.Interfaces;
using ToDo2.Parameters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoIOCController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoIOCController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }
        // GET: https://localhost:44396/api/TodoIOC
        /*
         * Demo using (IOC)Inverse of control design 
         * 
         * **/
        [HttpGet]
        public List<TodoListSelectDtos> Get([FromQuery]TodoSelectParameter value)
        {
            return _todoListService.GetData(value);
        }

    }
}
