using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue myQueue = new MyQueue();

            Citizen[] persons = new Citizen[]
            {
                new Student("Mark", "Brown", "MB12345"),
                new Worker("Bob", "Brown", "MB54231"),
                new Pensioner("Jhon", "Brown","ma3254235"),
                new Student("Lisa", "Brown","MA32521"),
                new Worker("Ann", "Brown","mb12345"), // Этот элемент не добавится.
                new Pensioner("Kevin", "Brown","MA48765"),
                new Worker("Rob", "Brown","MB58632"),
                new Student("Harry", "Brown","mcC32541")
            };

            foreach (var person in persons)
            {
                myQueue.AddToQueue(person);
            }
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("After adding:");
            foreach (var person in myQueue)
            {
                var result = myQueue.Contains(person);
                Console.WriteLine($"{person} : {result.index}");
            }

            myQueue.RemoveFirst(); // Удаление с начала коллекции
            myQueue.Remove(new Pensioner("Kevin", "Brown", "MA48765")); // Удаление с передачей экземпляра
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("After removing:");
            foreach (var person in myQueue)
            {
                var result = myQueue.Contains(person);
                Console.WriteLine($"{person} : {result.index}");
            }
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Return last:");
            var result1 = myQueue.ReturLast();
            Console.WriteLine($"{result1.citizen}: {result1.index}");
            Console.WriteLine(new string('-', 30));

            myQueue.Clear();
            Console.WriteLine("After clearing:");
            foreach (var person in myQueue)
            {
                var result = myQueue.Contains(person);
                Console.WriteLine($"{person} : {result.index}");
            }

            Console.ReadLine();
        }
    }
}
