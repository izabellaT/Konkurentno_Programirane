using System;
using System.Threading;

namespace Synchronized_Contexts
{
    class Program
    {
        static void Main()
        {
            CBO syncClass = new CBO();
            Console.WriteLine("Main thread starts 6 threads:\n" + "3 doing Job1 and 3 doing Job2.\n\n" + "Tasks should execute consequently.\n");
            for (int i = 0; i < 6; i++)
            {
                Thread t;
                if (i % 2 == 0)
                    t = new Thread(new ThreadStart(syncClass.DoSomeTask1));
                else
                    t = new Thread(new ThreadStart(syncClass.DoSomeTask2));
                t.Start();
            }
        }
    }
    class CBO : ContextBoundObject
    {
        public void DoSomeTask1()

        {

            Console.WriteLine("Job1 started.");

            Thread.Sleep(2000);

            Console.WriteLine("Job1 finished.\n");

        }



        public void DoSomeTask2()

        {

            Console.WriteLine("Job2 started.");

            Thread.Sleep(1500);

            Console.WriteLine("Job2 finished.\n");

        }

    }
}


