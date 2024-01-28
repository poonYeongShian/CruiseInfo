using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDIController : ControllerBase
    {
        private readonly TransientService _transientService;
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        private readonly TestDIService _testDIService;

        public TestDIController(TransientService transientService, SingletonService singletonService, ScopedService scopedService, TestDIService testDIService)
        {
            _transientService = transientService;
            _singletonService = singletonService;
            _scopedService = scopedService;

            _testDIService = testDIService;
        }



        // GET: api/<TestDIController>
        [HttpGet]
        public NumOfCount Get()
        {
            _testDIService.Execute();

            _transientService.Increment();
            _singletonService.Increment();
            _scopedService.Increment();

            var result = new NumOfCount { 
                Transient = _transientService.Count,
                Singleton = _singletonService.Count,
                Scoped = _scopedService.Count
            };

            return result;
        }

        // GET api/<TestDIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestDIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestDIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestDIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class NumOfCount
    {

        public int Transient { get; internal set; }
        public int Singleton { get; internal set; }
        public int Scoped { get; internal set; }
        public NumOfCount()
        {
            Transient = 0;
            Singleton = 0;
            Scoped = 0;
        }
    }
}
