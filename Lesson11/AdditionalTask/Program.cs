using System;
using System.Threading;

namespace AdditionalTask
{
    class Program
    {
        static private object block = new object();
        static private int counter;
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Procedure);
                threads[i].Start();
            }

            Console.ReadLine();
        }

        static void Procedure()
        {
            lock (block)
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;

                    Thread.Sleep(100);
                    Console.WriteLine($"Поток: {Thread.CurrentThread.ManagedThreadId}, counter{counter}");
                }


            }
        }
    }
}
