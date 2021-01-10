using System;
using System.Collections;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList1 = new SortedList()
            {
                { "C", "3" },
                { "D", "4" },
                { "A", "1" },
                { "B", "2" },
                { "E", "5" }
            };

            foreach (DictionaryEntry item in sortedList1)
            {
                Console.WriteLine($"[{item.Key}], [{item.Value}]");
            }

            Console.WriteLine(new string('-', 10));

            SortedList sortedList2 = new SortedList(new MyComparer())
            {
                { "C", "3" },
                { "D", "4" },
                { "A", "1" },
                { "B", "2" },
                { "E", "5" }
            };

            foreach (DictionaryEntry item in sortedList2)
            {
                Console.WriteLine($"[{item.Key}], [{item.Value}]");
            }

            Console.ReadLine();
        }
    }
}
