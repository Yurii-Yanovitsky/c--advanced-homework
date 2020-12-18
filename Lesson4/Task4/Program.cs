using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var ua = new CultureInfo("uk-UA");
            var en = new CultureInfo("en-US");

            string checkList = File.ReadAllText("CheckList.txt");
            Console.WriteLine(checkList);
            Console.WriteLine(new string('-', 30));
            checkList = Regex.Replace(checkList, @"грн", "");

            string pattern = @"\d+\.?\d+";
            string list1 = Regex.Replace(checkList, pattern, (price) => double.Parse(price.Value).ToString("C", ua));
            string list2 = Regex.Replace(checkList, pattern, (price) => double.Parse(price.Value).ToString("C", en));


            Console.WriteLine(list1);
            Console.WriteLine(new string('-', 30));
            Console.WriteLine(list2);

            Console.ReadLine();
        }
    }
}
