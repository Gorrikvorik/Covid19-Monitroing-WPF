using PR22.Services.Interfaces;
using System;
using System.Threading;

namespace PR22.Services
{
    internal class AsyncDataService : IAsyncDataService
    {
        private const int _SleepTime = 7000;
        public string GetResult(DateTime Time)
        {
            Thread.Sleep(_SleepTime);

            return $"Result value {Time}";
        }
    }
}
