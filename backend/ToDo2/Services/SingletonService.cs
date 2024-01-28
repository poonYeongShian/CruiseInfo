using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo2.Services
{
    public class SingletonService
    {
        public int Count = 0;

        public void Increment()
        {
            Count++;
        }
    }
}
