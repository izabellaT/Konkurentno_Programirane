using System;
using System.Threading;

namespace MutexZad
{
    class Program
    {
      
            const int THREAD_COUNT = 5;
            static void Main(string[] args)
            {
                Mutex commonMutex = new Mutex();
                Thread[] demoThreads = new Thread[THREAD_COUNT];
                for (int i = 0; i <THREAD_COUNT; i++)
{
                MutexThread mutexThread = new MutexThread(commonMutex);
                demoThreads[i] = new Thread(
                new ThreadStart(mutexThread.PerformSomeTask));
                demoThreads[i].Start();
            }
            foreach (Thread thread in demoThreads)
            {
                thread.Join();
            }
            Console.WriteLine("Main Thread Exist");
        }
    }
    class MutexThread
    {
        Mutex mMutex;
        public MutexThread(Mutex aMutex)
        {
            mMutex = aMutex;
        }
        public void PerformSomeTask()
        {

            mMutex.WaitOne();
            Thread.Sleep(200);
            Console.WriteLine("\nStarting some job...");
            for (int i = 0; i<10; i++)
{
                Thread.Sleep(100);
                Console.Write("|");
            }
            Console.WriteLine("\nJob finished.");
            mMutex.ReleaseMutex();
        }
    }
}