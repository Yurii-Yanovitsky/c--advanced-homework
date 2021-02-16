using System;
using System.Threading;

namespace Task2
{
    public class Program
    {
        //static private ManualResetEvent resetEvent = new ManualResetEvent(false);
        static private AutoResetEvent resetEvent = new AutoResetEvent(false);

        static void Main()
        {
            new Work(resetEvent);

            Console.WriteLine("Pause the execution of the primary thread.");
            resetEvent.WaitOne();

            Console.WriteLine("\nThe primary thread has resumed its work.");

            //resetEvent.Reset(); Вызываем Reset(), если используем ManualResetEvent.

            Console.WriteLine();

            new Work(resetEvent);

            Console.WriteLine("\nPause the execution of the primary thread.");
            resetEvent.WaitOne();

            Console.WriteLine("\nThe primary thread has resumed and finished its work.");

            Console.ReadKey();
        }
    }
    public class Work
    {
        //static private ManualResetEvent _resetEvent;
        static private AutoResetEvent _resetEvent;

        public Work(AutoResetEvent resetEvent)
        {
            new Thread(DoWork).Start();
            _resetEvent = resetEvent;
        }

        static void DoWork()
        {
            Thread.Sleep(200);

            Console.WriteLine($"\nThread {Thread.CurrentThread.ManagedThreadId} started work");

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 20; i++)
            {
                Console.Write("*");
                Thread.Sleep(200);
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine($"\nThread {Thread.CurrentThread.ManagedThreadId} finished work");

            _resetEvent.Set();
        }
    }
}
