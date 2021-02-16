using System;
using System.IO;
using System.Threading;

namespace Task2
{
    class Program
    {
        static private object block = new object();

        static void Main(string[] args)
        {
            Thread[] threads = { new Thread(() => WriteTo("result.txt", ReadFrom("textA.txt"))),
                                 new Thread(() => WriteTo("result.txt", ReadFrom("textB.txt")))
                               };

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            Console.ReadLine();
        }

        static void WriteTo(string filePath, string receivedText)
        {

            lock (block)
            {

                string resultLine = string.Format($"Writing result of thread {Thread.CurrentThread.ManagedThreadId} : {receivedText}");
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(resultLine);
                }

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished writing");
            }
        }

        static string ReadFrom(string filePath)
        {

            using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                return reader.ReadToEnd();
            }
        }
    }

}
