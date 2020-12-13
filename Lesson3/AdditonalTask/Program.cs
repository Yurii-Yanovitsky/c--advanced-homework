using System;
using System.IO;

namespace AdditonalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory($@"F:\Folder_{i}");
            }

            Console.WriteLine("100 folders have just been created! Press any key to delete them: ");
            Console.ReadLine();

            for (int i = 0; i < 100; i++)
            {
                Directory.Delete($@"F:\Folder_{i}");
            }

            Console.WriteLine("100 foledrs have just been deleted. Press any key to finish");
            Console.ReadLine();
        }
    }
}
