using System;

using System.Threading;



namespace SmallExample

{

    class ThreadClass
    {
        public void DoTask1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Thread1:job({0})", i);
                Thread.Sleep(1);
            }
        }
        public void DoTask2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Thread2:job({0})", i);

                Thread.Sleep(1);
            }
        }
    }
    class MainThread
    {
        static void Main(string[] args)
        {
            ThreadClass threadClass = new ThreadClass();
            Thread thread1 = new Thread(
               new ThreadStart(threadClass.DoTask1));
            Thread thread2 = new Thread(
               new ThreadStart(threadClass.DoTask2));
            thread1.Start();
            thread2.Start();
        }
    }
}
