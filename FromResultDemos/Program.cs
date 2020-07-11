using System;
using System.IO;
using System.Threading.Tasks;

namespace FromResultDemos
{
    class Program
    {
        public static string CacheData { get; set; }
        async static Task Main(string[] args)
        {
            CacheData = await GetDataAsync();

            Console.WriteLine(CacheData);
        }

        public static Task<string> GetDataAsync()
        {
            if (String.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("dosya.txt");
            }
            else
            {
                return Task.FromResult<string>(CacheData);
            }
        }
    }
}
