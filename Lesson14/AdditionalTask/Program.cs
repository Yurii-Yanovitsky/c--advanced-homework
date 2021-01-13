using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[] array = new int[1000000];

            Action<int> action = (i) => array[i] = random.Next(1000000);

            Parallel.For(0, array.Length, action);

            ParallelQuery<int> oddNumbers = array.AsParallel().Where((x) => x % 2 != 0).OrderBy(x => x);

            bool isNewLine = false;

            foreach (var n in oddNumbers)
            {

                if (!isNewLine)
                {
                    Console.Write(n);

                    isNewLine = true;

                }
                else
                {
                    Console.WriteLine(" " + n);

                    isNewLine = false;
                }

            }

            Console.WriteLine("*Finished*");

            Console.ReadLine();
        }
    }
}
