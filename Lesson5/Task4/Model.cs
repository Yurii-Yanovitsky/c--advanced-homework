#define ConfigFile

namespace Task4
{
    public class Model
    {
        public ISettings Settings;

        public Model()
        {
#if ConfigFile
            Settings = new SettingsConfig();
#else
            Settings = new SettingsRegistry();
#endif
        }
    }
}

