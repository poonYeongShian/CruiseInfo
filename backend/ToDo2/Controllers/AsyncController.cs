using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        private readonly AsyncService _asyncService;
        public AsyncController(AsyncService asyncService)
        {
            _asyncService = asyncService;
        }

        /*
         * Demo Asyc await
         * **/
        // GET: api/<AsyncController>
        [HttpGet]
        public async Task<int> Get()
        {
            return await _asyncService.MainTask();
        }

      
    }
}
