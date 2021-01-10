using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter URL: ");
            string url = Console.ReadLine();

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseResult = reader.ReadToEnd();
            reader.Close();

            StreamWriter writer = File.CreateText("Result.txt");

            Regex regex = new Regex(@"href='(?<link>\S+)'>");

            foreach (Match m in regex.Matches(responseResult))
            {
                writer.WriteLine($"Ссылка: {m.Groups["link"]}");
            }

            regex = new Regex(@"(?<phone>[+3(0-9)\s]{2,}[0-9]{3}[\s\-][0-9]{2}[\s\-][0-9]{2})");


            foreach (Match m in regex.Matches(responseResult))
            {
                writer.WriteLine($"Телефон: {m.Groups["phone"]}");
            }


            regex = new Regex(@"(?<email>[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4})");

            foreach (Match m in regex.Matches(responseResult))
            {
                writer.WriteLine($"E-Mail: { m.Groups["email"]}");
            }

            writer.Close();
            Console.ReadKey();
        }
    }
}
