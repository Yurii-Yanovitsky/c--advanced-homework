using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main started");

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;


            Task task = new Task(() => Parallel.Invoke(options, MyTask1, MyTask2));
            task.Start();

            Console.WriteLine("Main finished");

            Console.ReadLine();
        }

        static void MyTask1()
        {
            Thread.CurrentThread.IsBackground = false;

            Console.WriteLine($"MyTask1 started");

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("+");
            }

            Console.WriteLine($"MyTask1 finished");
        }

        static void MyTask2()
        {
            Thread.CurrentThread.IsBackground = false;

            Console.WriteLine($"MyTask2 started");

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("-");
            }

            Console.WriteLine($"MyTask2 finished");
        }
    }
}
