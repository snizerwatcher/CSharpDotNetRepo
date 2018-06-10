using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedConceptPOC.ThreadPoc;
using System.Threading;

namespace AdvancedConceptPOC
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Join Example
            //ThreadPOC threadPoc = new ThreadPOC();
            //ThreadStart work = new ThreadStart(threadPoc.StartThreadPOCJoin);
            //Thread t = new Thread(work);
            //t.Start();
            //Console.WriteLine("Start Main");
            //t.Join();
            //Console.ReadKey();

            //BackGround ForeGround Example
            //ThreadPOC threadPoc = new ThreadPOC();
            //ThreadStart work = new ThreadStart(threadPoc.StartThreadPOCBackgroundThread);
            //Thread t = new Thread(work);
            //t.Start();

            //ParametrizedThreadStart Delegate
            //ThreadPOC threadPoc = new ThreadPOC();
            //ThreadStart work = new ThreadStart(threadPoc.StartThreadPOCparametrizedThread);
            //Thread t = new Thread(work);
            //t.Start();


            // [ThreadStatic]            
            //ThreadStart work = new ThreadStart(ThreadPOC.UseOfThreadAttribute);
            //Thread t = new Thread(work);
            //t.Start();

            //Thread Pool Example
            ThreadPOC threadPoc = new ThreadPOC();
            ThreadStart work = new ThreadStart(threadPoc.ThreadPoolExample);
            Thread t = new Thread(work);
            t.Start();


        }
    }
}
