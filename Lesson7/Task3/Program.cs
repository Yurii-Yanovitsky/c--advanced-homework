using System;
using System.Linq;
using System.Reflection;
using AdditionalTask;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(Worker).Assembly;

            Console.WriteLine("Specify the members that you want to display: (method, field, prop, ctor, interface)");
            var input = Console.ReadLine()
                .Split("', '".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower()).ToArray();

            Console.WriteLine("\n" + new string(' ', 47)+"RESULT");

            Reflector reflector = new Reflector(assembly, input);
            reflector.GetTypeAndMembersInfo();

            Console.ReadLine();
        }
    }
}
