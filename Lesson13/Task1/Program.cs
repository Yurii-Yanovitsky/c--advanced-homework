using System;
using System.Runtime.Remoting.Messaging;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your name: ");
            string input = Console.ReadLine();

            Func<string, string> myDlegate = SayHi;

            myDlegate.BeginInvoke(input, CallBackMethod, null);


            Console.WriteLine("Primary thread has finished work");

            Console.ReadLine();
        }

        static string SayHi(string Name)
        {
            return $"Hi, {Name}";
        }

        static void CallBackMethod(IAsyncResult asyncResult)
        {

            var func = ((AsyncResult)asyncResult).AsyncDelegate as Func<string, string>;

            string output = func.EndInvoke(asyncResult);

            Console.WriteLine(output);

        }
    }
}
