using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class Program
    {
        static private object block = new object();
        static private int counter;
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            for (int i = 0; i < 3; i++)
            {
                tasks[i] = StartTask();
            }

            Task.WaitAll(tasks);

            Console.ReadLine();
        }

        static async Task StartTask()
        {
            await Task.Factory.StartNew(Procedure);
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
