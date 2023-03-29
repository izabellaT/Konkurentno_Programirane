using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started.");
            ThreadClass threadClass = new ThreadClass();
            Thread thread1 = new Thread(new ThreadStart(threadClass.DoTask1));
            Thread thread2 = new Thread(new ThreadStart(threadClass.DoTask2));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Main thread finished.");
        }
    }
}
