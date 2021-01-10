using System;
using System.IO;

namespace MyDecorators
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World";

            StreamWriter streamWriter = File.CreateText("F:/Test.txt");
            Writer writer = new UperCaseWriter(streamWriter);
            writer = new RepeatWriter(writer, 2);
            writer = new InserWriter(writer, "_");
            writer.Write(text);
            writer.Close();

            Console.WriteLine("Text has been written to F:/Test.txt");

            Console.ReadLine();
        }
    }
}
