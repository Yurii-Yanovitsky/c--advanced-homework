using System;
using System.Text.RegularExpressions;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Login: ");
                string login = Console.ReadLine();

                Console.Write("Passwor: ");
                string password = Console.ReadLine();

                var m1 = Regex.Match(login, @"^[A-z]+$");
                var m2 = Regex.Match(password, @"^[\S]{5,}$");

                if (!m1.Success || !m2.Success)
                {
                    Console.WriteLine("ERROR: invalid login or password!");
                    Console.WriteLine("Try again");
                }
                else
                {
                    isValid = true;
                }
            }

            Console.WriteLine("It went well!");

            Console.ReadLine();
        }
    }
}
