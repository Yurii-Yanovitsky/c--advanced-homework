using System.IO;
using System.IO.Compression;

namespace Task3
{
    class Model
    {
        public string FilePath { get; private set; }
        public bool IsPath { get; private set; }

        public string CompressFile()
        {
            FileStream source = new FileStream(FilePath, FileMode.Open);
            FileStream destination = File.Create(Path.GetDirectoryName(FilePath) + @"\archive.zip");

            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

            int inputByte = source.ReadByte();
            while (inputByte != -1)
            {
                compressor.WriteByte((byte)inputByte);
                inputByte = source.ReadByte();

            }

            compressor.Close();

            return destination.Name;
        }

        public string ShowFileContent()
        {
            StreamReader streamReader = File.OpenText(FilePath);
            string content = streamReader.ReadToEnd();
            streamReader.Close();

            return content;
        }

        public bool SearchFile(string targetDirectory, string fileName)
        {
            DirectoryInfo dir = new DirectoryInfo(targetDirectory);
            FileInfo[] fileInfo;

            if (!dir.Exists)
            {
                return false;
            }

            fileInfo = dir.GetFiles(fileName);

            if (fileInfo.Length == 0)
            {
                foreach (var directory in dir.GetDirectories())
                {
                    if (directory.Attributes == (FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory))
                    {
                        continue;
                    }
                    else if (SearchFile(directory.FullName, fileName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                FilePath = fileInfo[0].FullName;
                IsPath = true;

                return true;
            }
        }
    }
}
