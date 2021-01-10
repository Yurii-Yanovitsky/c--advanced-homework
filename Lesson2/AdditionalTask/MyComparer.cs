using System.Collections;

namespace AdditionalTask
{
    class MyComparer : IComparer
    {
        public int Compare(object y, object x)
        {
            string a = x as string;
            string b = y as string;

            return string.Compare(a, b);
        }
    }
}
