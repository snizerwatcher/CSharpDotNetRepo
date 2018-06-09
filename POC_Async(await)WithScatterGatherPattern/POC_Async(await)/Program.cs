using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Async_await_
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> consumerData = new List<string>();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            Console.WriteLine("=============SIMPLE LOOP START================");

            for (int i = 0; i < 180000;i++)
            {
                consumerData.Add(i.ToString());
            }

            

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(consumerData.Count.ToString());
            Console.WriteLine(elapsedMs.ToString());



            Console.WriteLine("============IMPLEMENTATION 1=================");

            watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
           
            List<string> result = new List<string>();

            scatterGather main = new scatterGather();

            result = main.start(consumerData).GetAwaiter().GetResult();

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(result.Count.ToString());
            Console.WriteLine(elapsedMs.ToString());



            Console.WriteLine("============IMPLEMENTATION 2================");

            watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            result = main.start2(consumerData).GetAwaiter().GetResult();

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(result.Count.ToString());
            Console.WriteLine(elapsedMs.ToString());


            Console.ReadKey();
        }

      
       
    }
}
