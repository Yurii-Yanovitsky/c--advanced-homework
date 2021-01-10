using System;
using System.Xml;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Users.xml");
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            GetXmlDocumentInfo(xmlRoot);

            void GetXmlDocumentInfo(XmlNode xmlNode)
            {
                Console.WriteLine($"Node Type: {xmlNode.NodeType}, Name: {xmlNode.Name}, Value: {xmlNode.Value}, InnerText {xmlNode.InnerText}");

                foreach (XmlNode xNode in xmlNode)
                {
                    if (xNode is XmlElement xmlElement && xmlElement.HasAttributes)
                    {
                        foreach (XmlAttribute attr in xmlElement.Attributes)
                        {
                            Console.WriteLine(new string(' ', 3) + $"Node Type: {attr.NodeType}, Name: {attr.Name}, Value: {attr.Value}, InnerText: {attr.InnerText}");
                        }
                    }

                    if (xNode.HasChildNodes)
                    {
                        foreach (XmlNode node in xNode.ChildNodes)
                        {
                            Console.Write(new string(' ', 6));
                            GetXmlDocumentInfo(node);
                        }
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
