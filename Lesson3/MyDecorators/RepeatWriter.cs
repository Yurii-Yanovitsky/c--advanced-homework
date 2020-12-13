using System.Text;
using System.IO;

namespace MyDecorators
{
    public class RepeatWriter : Writer
    {
        private readonly int _count;

        public RepeatWriter(StreamWriter stream, int count)
        {
            StreamWriter = stream;
            _count = count;
        }

        public RepeatWriter(Writer writer, int count) : this(writer.StreamWriter, count)
        {
            PreviousWriter = writer;
        }

        public override void Write(string text)
        {
            StringBuilder newText = new StringBuilder();

            for (int i = 0; i < _count; i++)
            {
                newText.Append(text);
            }

            if (PreviousWriter == null)
            {
                StreamWriter.WriteLine(newText.ToString());
            }

            else if (PreviousWriter != null)
            {
                PreviousWriter.Write(newText.ToString());
            }
        }
    }
}
