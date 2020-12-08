using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection collection = new Collection(15);

            var c1 = new Customer("Erick", 21321213);
            var c2 = new Customer("Ann", 00045235);
            var c3 = new Customer("Jhon", 75464421);
            var c4 = new Customer("Scott", 95863732);

            collection.Add(c1, Category.Appliances);
            collection.Add(c2, Category.Clothes);
            collection.Add(c3, Category.Laptops);
            collection.Add(c4, Category.Sports);
            collection.Add(c4, Category.Laptops);
            collection.Add(c4, Category.Clothes);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));

            var categoryList = collection[c1];
            Console.Write($"{c1.Name}: ");
            foreach (var category in categoryList)
            {
                Console.WriteLine($"{category}, ");
            }

            var customerList = collection[Category.Clothes];
            Console.Write($"{Category.Clothes}: ");
            foreach (var customer in customerList)
            {
                Console.Write($"{customer.Name}, ");
            }

            Console.ReadLine();
        }
    }
}
