using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo2.Dtos;
using ToDo2.Parameters;
using ToDo2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAsyncController : ControllerBase
    {
        private readonly TodoAsyncService _todoAsyncService;
        public TodoAsyncController(TodoAsyncService todoAsyncService)
        {
            _todoAsyncService = todoAsyncService;
        }

        /*
         * Demo async await GET
         * **/
        [HttpGet]
        public async Task<List<TodoListSelectDtos>> Get([FromQuery] TodoSelectParameter value)
        {
            return await _todoAsyncService.GetData(value);
        }

        /*
         * Demo async await POST
         * **/
        [HttpPost]
        public async Task Post([FromBody] TodoListPostDtos value)
        {
            await _todoAsyncService.AddNewData(value);
        }

    }
}
