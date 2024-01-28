using System;
using System.Threading.Tasks;

namespace ToDo2.Services
{
    public class AsyncService
    {
        public AsyncService() {
        
        }
        /*
         * Demo async await, which is a kind of parallel computing
         * **/
        public async Task<int> MainTask()
        {
            var Task1Result = Task1Async();
            var Task2Result = Task2Async();
            var Task3Result = Task3Async();

            int result = await Task1Result + await Task2Result + await Task3Result;

            return result;
        }

        private async Task<int> Task1Async()
        {
            await Task.Delay(1000);
            return 1;
        }
        private async Task<int> Task2Async()
        {
            await Task.Delay(2000);
            return 2;
        }
        private async Task<int> Task3Async()
        {
            await Task.Delay(3000);
            return 3;
        }
    }

    
}
