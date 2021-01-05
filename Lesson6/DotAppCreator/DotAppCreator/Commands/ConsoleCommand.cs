using System.Xml;
using System.IO;
using CommandInterface;

namespace DotAppCreator
{
    public class ConsoleCommand : ICommand
    {
        private XmlDocument _xDoc = new XmlDocument();
        private string _initialCode;

        public ConsoleCommand()
        {
            _xDoc.Load("ConsoleTemplate.xml");

            using (StreamReader reader = new StreamReader("InitialCode.txt"))
            {
                _initialCode = reader.ReadToEnd();
            }
        }

        public void Execute(string projectName, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = @$"{path}/{projectName}.csproj";
            _xDoc.Save(fullPath);

            using (StreamWriter writer = new StreamWriter(@$"{path}/Programm.cs"))
            {
                writer.WriteLine(_initialCode.Replace("*Project*", projectName));
            }
        }
    }
}
