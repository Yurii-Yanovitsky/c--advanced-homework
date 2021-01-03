#define ConfigFile

using System;
using System.Windows.Media;
using Microsoft.Win32;

namespace Task4
{
    public class SettingsRegistry : ISettings
    {
        private RegistryKey _key;
        private readonly BrushConverter _converter = new BrushConverter();

        public SettingsRegistry()
        {
            LoadSettings();
            ReadFromRegistry();
        }

        public Brush BackColor { get; set; }
        public Brush TextColor { get; set; }
        public double FontSize { get; set; }
        public FontFamily FontStyle { get; set; }

        public void Save()
        {
            _key.SetValue("BackColor", BackColor);
            _key.SetValue("TextColor", TextColor);
            _key.SetValue("FontSize", FontSize);
            _key.SetValue("FontStyle", FontStyle);
        }

        private void ReadFromRegistry()
        {
            try
            {
                BackColor = (Brush)_converter.ConvertFromString(_key.GetValue("BackColor").ToString());
            }
            catch (Exception)
            {
                BackColor = (Brush)_converter.ConvertFromString(Colors.White.ToString());

            }

            try
            {
                TextColor = (Brush)_converter.ConvertFromString(_key.GetValue("TextColor").ToString());
            }
            catch (Exception)
            {
                TextColor = (Brush)_converter.ConvertFromString(Colors.Black.ToString());

            }

            try
            {
                FontSize = double.Parse(_key.GetValue("FontSize").ToString());
            }
            catch (Exception)
            {
                FontSize = 14;

            }

            try
            {
                FontStyle = new FontFamily(_key.GetValue("FontStyle").ToString());
            }
            catch (Exception)
            {
                FontStyle = new FontFamily("Arial");
            }
        }

        private void LoadSettings()
        {
            RegistryKey registryKey = Registry.CurrentUser;
            _key = registryKey.OpenSubKey("MyAppSettings", true);

            if (_key == null)
            {
                _key = registryKey.CreateSubKey("MyAppSettings", true);
                _key.SetValue("BackColor", "");
                _key.SetValue("TextColor", "");
                _key.SetValue("FontSize", "");
                _key.SetValue("FontStyle", "");
            }
        }
    }
}

