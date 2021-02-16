using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;

namespace DotAppCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Assembly> additionalCommandAssembly = new Assembly[0];

            try
            {
                additionalCommandAssembly = new DirectoryInfo("./plugins")
                .GetFiles("*.dll").Select(dllFile => Assembly.LoadFrom(dllFile.FullName));
            }

            catch
            {
                Console.WriteLine("Failed to load additional assemblies");
            }

            var commandAssemblies = additionalCommandAssembly.Prepend(Assembly.GetExecutingAssembly()).ToArray();

            DotAppCreator appCreator = new DotAppCreator(commandAssemblies);

            while (true)
            {
                Console.Write("Your Command: ");
                string input = Console.ReadLine();
                appCreator.ExecuteCommand(input);
            }
        }
    }
}
