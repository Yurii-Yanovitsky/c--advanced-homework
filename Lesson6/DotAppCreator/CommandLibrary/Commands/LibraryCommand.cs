using System.IO;
using System.Reflection;
using System.Xml;
using CommandInterface;

namespace CommandLibrary
{
    public class LibraryCommand : ICommand
    {
        private XmlDocument _xDoc = new XmlDocument();
        private string _initialCode;
        private readonly Assembly _assembly;

        public LibraryCommand()
        {
            _assembly = typeof(LibraryCommand).Assembly;
            LoadTemplates();
        }

        public void Execute(string projectName, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = @$"{path}/{projectName}.csproj";
            _xDoc.Save(fullPath);

            using (StreamWriter writer = new StreamWriter(@$"{path}/Program.cs"))
            {
                writer.WriteLine(_initialCode.Replace("*Library*", projectName));
            }
        }

        private void LoadTemplates()
        {
            _xDoc.Load(_assembly.GetManifestResourceStream("CommandLibrary.LibraryTemplate.xml"));

            using (StreamReader reader = new StreamReader(_assembly.GetManifestResourceStream("CommandLibrary.InitialCode.txt")))
            {
                _initialCode = reader.ReadToEnd();
            }
        }
    }
}
