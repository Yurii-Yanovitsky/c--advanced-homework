using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите необходимый текст для дешифровки: ");
            string inputText = Console.ReadLine();

            // Создаем файл
            StreamWriter writer = File.CreateText("Test.txt");
            writer.WriteLine(inputText);
            writer.Close();

            string text = File.ReadAllText("Test.txt");

            Regex regex = new Regex(@"\b[а-я]{1,3}\b");
            string replacedText = regex.Replace(text, "ГАВ!");

            // Выведем измененную строку
            Console.WriteLine(replacedText);

            File.WriteAllText("Test.txt", replacedText);

            Console.ReadLine();
        }
    }
}
