using System;
using System.Reflection;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"Task2");
            dynamic instance = assembly.CreateInstance("Task2.Temperature");

            Console.Write("Enter the temperature value in °C: ");
            decimal temp = decimal.TryParse(Console.ReadLine(), out temp) == true ? temp : 0m;
            Console.WriteLine($"{temp} °C = {instance.Fahrenheit(temp)} °F");
            Console.WriteLine($"{temp} °C = {instance.Kelvin(temp)} K");

            Console.ReadLine();
        }
    }
}
