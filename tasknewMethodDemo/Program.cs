using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace tasknewMethodDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var mytask = Task.Factory.StartNew
                ((obj) =>
                 {
                     Console.WriteLine("startnew çalıştı");
                     Deneme d = obj as Deneme;
                     d.ThreadId = Thread.CurrentThread.ManagedThreadId;

                 },
                    new Deneme()
                    {
                        Date = DateTime.Now
                    }
                );

            await mytask;

            Deneme d = mytask.AsyncState as Deneme;

            Console.WriteLine(d.ThreadId);
            Console.WriteLine(d.Date.ToString());

         var myTask2=   Task.Factory.StartNew((x) => { Deneme deneme = x as Deneme; }, new MyState() { Yuzde = 111 });

            await myTask2;

            Console.WriteLine((myTask2.AsyncState as MyState).Yuzde);
        }
    }


    public class Deneme
    {
        public int ThreadId { get; set; }
        public DateTime Date { get; set; }
    }
}
