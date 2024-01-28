using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo2.Services
{
    public class TestDIService
    {
        private readonly TransientService _transientService;
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;

        public TestDIService(TransientService transientService, SingletonService singletonService, ScopedService scopedService)
        {
            _transientService = transientService;
            _singletonService = singletonService;
            _scopedService = scopedService;
        }
        
        //Execute increment
        public void Execute()
        {
            _transientService.Increment();
            _singletonService.Increment();
            _scopedService.Increment();
        }
    }   
}
