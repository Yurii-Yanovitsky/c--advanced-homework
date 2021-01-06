using System;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator validator = new Validator();

            Worker[] workers = { new Programmer(), new Manager(), new Director(), new OrdinaryWorker() };

            foreach (var worker in workers)
            {
                var (isValid, typeName) = validator.Validate(worker);

                if (isValid)
                {
                    Console.WriteLine($"{typeName} - Access is allowed.");
                }
                else
                {
                    Console.WriteLine($"{typeName} - Access is denied.");
                }
            }

            Console.ReadLine();
        }
    }
}
