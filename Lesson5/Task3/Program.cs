using System;
using System.IO;
using System.Xml;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("TelephoneBook.xml");

            var root = xmlDocument.DocumentElement;

            foreach (XmlElement xElement in root)
            {
                if (xElement.HasAttributes && xElement.Name == "Contact")
                {
                    Console.WriteLine($"Phone number: {xElement.GetAttribute("TelephoneNumber")}");
                }
            }

            Console.ReadKey();
        }
    }
}
