using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedConceptPOC.ThreadPoc
{
    public class ThreadPOC
    {

        [ThreadStatic]
        public static int _field;
        void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread: {0}", i);
                Thread.Sleep(0);
            }

        }

        void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("First Thread: {0}", i);
                Thread.Sleep(500);
            }

        }

        void ThreadMethod1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread: {0}", i);
                Thread.Sleep(1000);
            }

        }

        public void StartThreadPOCJoin()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            t.Join();
        }

        public void StartThreadPOCBackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod1));

            t.IsBackground = true;  // exit the program immediately for true  
            t.Start();
            
            
        }

        public void StartThreadPOCparametrizedThread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));

            t.IsBackground = false;  // wait for the application to exit.
            t.Start(8);


        }


        public static void UseOfThreadAttribute()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }

        public void ThreadPoolExample()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }

    }
}
