using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Months months = new Months();

            var result1 = months.GetMonthByNumber(12);
            var result2 = months.GetMonthByDays(31);

            Console.Write("By number: ");
            foreach (var m in result1)
            {
                Console.Write(m);
            }

            Console.WriteLine();

            Console.Write("By days: ");
            foreach (var m in result2)
            {
                Console.Write($"{m}, ");
            }

            Console.ReadLine();
        }
    }
}
