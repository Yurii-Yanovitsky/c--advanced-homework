
using System.IO;
using System.IO.IsolatedStorage;

namespace Task4
{
    class Model
    {
        public string SaveColorToStorage(object selectedColor)
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("ColorSettings.set", FileMode.Create, userStorage);

            StreamWriter streamWriter = new StreamWriter(userStream);

            streamWriter.WriteLine(selectedColor);
            streamWriter.Close();

            return $"Цвет {selectedColor} сохранен";
        }

        public string GetColorFromStorage()
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("ColorSettings.set", FileMode.OpenOrCreate, userStorage);

            StreamReader streamReader = new StreamReader(userStream);

            string color = streamReader.ReadToEnd();
            streamReader.Close();

            return color;
        }

    }
}
