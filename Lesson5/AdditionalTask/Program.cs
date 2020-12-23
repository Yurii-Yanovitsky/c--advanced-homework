using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDocument = new XDocument(new XElement("MyContacts",
                     new XElement("Contact",
                     new XAttribute("TelephoneNumber", "0952232425"), "Vlad")));
            xDocument.Save("TelephoneBook.xml");

            XmlTextReader xmlReader = new XmlTextReader(File.OpenRead("TelephoneNumber.xml"));

            while (xmlReader.Read())
            {
                Console.WriteLine($"NodeType: {xmlReader.NodeType} Name: { xmlReader.Name} Value: {xmlReader.Value}");
            }

            xmlReader.Close();

            Console.ReadKey();
        }
    }
}
