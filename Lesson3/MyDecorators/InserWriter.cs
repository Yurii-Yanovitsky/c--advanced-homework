using System.Text;
using System.IO;

namespace MyDecorators
{
    public class InserWriter : Writer
    {
        private readonly string _insertElement;

        public InserWriter(StreamWriter streamWriter, string insertElement)
        {
            StreamWriter = streamWriter;
            _insertElement = insertElement;
        }

        public InserWriter(Writer writer, string insertElement) : this(writer.StreamWriter, insertElement)
        {
            PreviousWriter = writer;
        }

        public override void Write(string text)
        {
            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] != ' ')
                {
                    newText.Append(text[i] + _insertElement);
                }
            }
            newText.Append(text[text.Length - 1]);

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
