using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"F:\MyDir\file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine("Hi! How are you doing?");
            streamWriter.Close();

            StreamReader streamReader = File.OpenText(@"F:\MyDir\file.txt");
            string result = streamReader.ReadToEnd();
            streamReader.Close();

            Console.Write(result);

            Console.ReadLine();
        }
    }
}
