using System.IO;

namespace MyDecorators
{
    public abstract class Writer
    {
        public StreamWriter StreamWriter { get; protected set; }
        protected Writer PreviousWriter { get; set; }
        abstract public void Write(string text);
        public void Close()
        {
            StreamWriter.Close();
        }
    }
}
