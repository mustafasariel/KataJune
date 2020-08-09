using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskResultDemos
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("m1");

            var myTask = GetDataAsync();

            Console.WriteLine("m2");

            var content = await myTask;

            Console.WriteLine("m3");
        }

   
        private async static Task<string> GetDataAsync()
        {
            Console.WriteLine("g1");
            var task =await new HttpClient().GetStringAsync("https://www.goog.com");
            Console.WriteLine("g2");
            return  task;
        }
    }
}
