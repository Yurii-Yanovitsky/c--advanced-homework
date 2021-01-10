using System;
using System.Collections;
using System.Collections.Specialized;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Name1", "Last Name1", 2312349);
            User user2 = new User("Name2", "Last Name2", 2312345);
            User user3 = new User("Name3", "Last Name3", 1223441);
            User user4 = new User("Name4", "Last Name4", 1223441); // Ключ не добавится

            IEqualityComparer comparer = user1;

            OrderedDictionary orderedDictionary = new OrderedDictionary(comparer)
            {
                { user1, "PK1" },
                { user2, "PK2" },
                { user3, "PK3" }
            };

            try
            {
                orderedDictionary.Add(user4, "PK4");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (DictionaryEntry item in orderedDictionary)
            {
                Console.WriteLine($"{item.Key}, {item.Value}");
            }

            Console.ReadLine();
        }
    }
}
