using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static private Mutex mutex = new Mutex(false, "MyMutex:: CODE");

        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                new Thread(Function).Start();
            }

            Console.ReadKey();
        }

        static void Function()
        {
            mutex.WaitOne();

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ----> has entered the protected area");

            for (int i = 0; i < 20; i++)
            {
                Console.Write("-");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nThread {Thread.CurrentThread.ManagedThreadId} <---- has left the protected area");

            mutex.ReleaseMutex();
        }
    }
}
