using System;
using System.Collections;
using Collections.MyLibrary;
using System.Linq;
using System.Collections.Generic;

namespace Task3
{
    class MyQueue : IEnumerable<Citizen>
    {
        private readonly MyLinkedList<Citizen> queue;

        public MyQueue()
        {
            queue = new MyLinkedList<Citizen>();
        }

        public int AddToQueue(Citizen citizen)
        {
            if (citizen == null)
            {
                Console.WriteLine("No data about this person!");
                return -1;
            }

            var result = Contains(citizen); // Проверяем на наличие данного человека в очереди  
            if (result.isContained)
            {
                Console.WriteLine($"There is already a person in the queue with such a passport: {citizen.Passport}!");
                return result.index;
            }

            if (citizen as Pensioner != null)
            {
                var currentNode = queue.FirstNode;
                while (currentNode.Value is Pensioner) // Получаем последнего в очереди пенсионера
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode.Value as Pensioner != null)
                {
                    queue.AddAfter(currentNode, citizen);
                }
                else
                {
                    queue.AddBefore(currentNode, citizen); // Если первый элемент в очереди не пенсионер
                }
            }
            else
            {
                queue.AddLast(citizen);
            }
            return queue.ToList().IndexOf(citizen);
        }

        public void RemoveFirst()
        {
            queue.RemoveFirst();
        }

        public void Remove(Citizen citizen)
        {
            queue.Remove(citizen);
        }
        public (Citizen citizen, int index) ReturLast()
        {
            Citizen citizen = queue.Last();
            return (citizen, queue.ToList().IndexOf(citizen));
        }
        public void Clear()
        {
            queue.Clear();
        }

        public (bool isContained, int index) Contains(Citizen citizen)
        {
            int index = -1;
            foreach (var person in queue)
            {
                index++;
                if (person.Equals(citizen))
                {
                    return (true, index);
                }
            }
            return (false, -1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        public IEnumerator<Citizen> GetEnumerator()
        {
            return queue.GetEnumerator();
        }
    }
}
