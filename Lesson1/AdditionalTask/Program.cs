using System;
using System.Collections.Generic;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = GetNumbersRaisedToPow((x) => x % 2 != 0, numbers);

            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }
        public static IEnumerable<double> GetNumbersRaisedToPow(Func<int, bool> action, params int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (action(number))
                {
                    yield return Math.Pow(number, 2);
                }
            }
        }
    }
}
