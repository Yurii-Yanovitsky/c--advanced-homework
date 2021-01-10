using System.IO;
using System.Xml;
using System.Windows.Media;

namespace Task4
{
    public class SettingsConfig : ISettings
    {
        private readonly string _fileName = @"Settings.config";
        private readonly BrushConverter _converter = new BrushConverter();
        private XmlDocument _xmlDocument = null;

        public SettingsConfig()
        {
            LoadFile();
            ReadFile();

        }

        public Brush BackColor { get; set; }
        public Brush TextColor { get; set; }
        public double FontSize { get; set; }
        public FontFamily FontStyle { get; set; }

        public void Save()
        {
            var node = _xmlDocument.DocumentElement["appSettings"];

            (node.SelectSingleNode("//add[@BackColor]") as XmlElement)?.SetAttribute("BackColor", BackColor.ToString());
            (node.SelectSingleNode("//add[@TextColor]") as XmlElement)?.SetAttribute("TextColor", TextColor.ToString());
            (node.SelectSingleNode("//add[@FontSize]") as XmlElement)?.SetAttribute("FontSize", FontSize.ToString());
            (node.SelectSingleNode("//add[@FontStyle]") as XmlElement)?.SetAttribute("FontStyle", FontStyle.ToString());

            _xmlDocument.Save(_fileName);
        }

        private void ReadFile()
        {
            var node = _xmlDocument?.DocumentElement["appSettings"];

            if (node != null)
            {
                BackColor = (Brush)_converter.ConvertFromString(node.SelectSingleNode("//add[@BackColor]").Attributes["BackColor"].Value);
                TextColor = (Brush)_converter.ConvertFromString(node.SelectSingleNode("//add[@TextColor]").Attributes["TextColor"].Value);
                FontSize = double.Parse(node.SelectSingleNode("//add[@FontSize]").Attributes["FontSize"].Value);
                FontStyle = new FontFamily(node.SelectSingleNode("//add[@FontStyle]").Attributes["FontStyle"].Value);
            }
            else
            {
                BackColor = (Brush)_converter.ConvertFromString(Colors.White.ToString());
                TextColor = (Brush)_converter.ConvertFromString(Colors.Black.ToString());
                FontSize = 14;
                FontStyle = new FontFamily("Arial");
            }
        }

        private void LoadFile()
        {
            if (File.Exists(_fileName))
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(_fileName);
            }
        }
    }
}

