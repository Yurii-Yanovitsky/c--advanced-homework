using System.IO;

namespace MyDecorators
{
    public class UperCaseWriter : Writer
    {
        public UperCaseWriter(StreamWriter streamWriter)
        {
            StreamWriter = streamWriter;
        }

        public UperCaseWriter(Writer writer)
        {
            PreviousWriter = writer;
        }

        public override void Write(string text)
        {
            if (PreviousWriter == null)
            {
                StreamWriter.WriteLine(text.ToUpper());
            }

            else if (PreviousWriter != null)
            {
                PreviousWriter.Write(text.ToUpper());
            }
        }
    }
}
