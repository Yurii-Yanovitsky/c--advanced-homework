using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> dic = new Dictionary<int, double>();

            dic.Add(653543, 765979.87);
            dic.Add(574522, 123100.55);
            dic.Add(454381, 100090);

            foreach (var item in dic)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            SortedDictionary<int, double> sortDic = new SortedDictionary<int, double>();

            sortDic.Add(653543, 765979.87);
            sortDic.Add(574522, 123100.55);
            sortDic.Add(454381, 100090);

            foreach (var item in sortDic)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
