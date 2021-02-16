using System;
using System.IO;
using System.Threading;

namespace AdditionalTask
{
    class Program
    {
        static private Semaphore semaphore = semaphore = new Semaphore(1, 2);

        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                new Thread(Resource).Start();
            }

            Console.ReadLine();
        }

        static void Resource()
        {
            semaphore.WaitOne();

            string entered = $"Thread {Thread.CurrentThread.ManagedThreadId} has entered";
            string exit = $"Thread {Thread.CurrentThread.ManagedThreadId} has exited";

            Console.WriteLine(entered);

            using (StreamWriter writer = new StreamWriter("report.log", true))
            {
                writer.WriteLine(entered);
                Thread.Sleep(500);
                writer.WriteLine(exit);
            }

            Console.WriteLine(exit);

            semaphore.Release();
        }
    }
}
