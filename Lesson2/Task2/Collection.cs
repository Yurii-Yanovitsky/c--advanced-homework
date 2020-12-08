using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Collection : IEnumerable<Entry>
    {
        private LinkedList<Entry>[] buckets;

        public Collection(int size = 15)
        {
            buckets = new LinkedList<Entry>[size];
        }

        public void Add(Customer customer, Category product)
        {
            int index = customer.GetHashCode() % buckets.Length;

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<Entry>();
            }
            if (customer != null && buckets[index].Any((x) => x.Customer.Equals(customer)))
            {
                var targetElement = buckets[index].First((x) => x.Customer.Equals(customer));
                targetElement.Products.Add(product);
            }
            else if (customer != null)
            {
                Entry entry = new Entry(customer, product);
                buckets[index].AddLast(entry);
            }
        }

        public List<Category> this[Customer customer]
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.Customer.Equals(customer))
                    {
                        return item.Products;
                    }
                }
                return default;
            }
        }

        public List<Customer> this[Category category]
        {
            get
            {
                List<Customer> customers = new List<Customer>();
                foreach (var entry in this)
                {
                    foreach (var item in entry.Products)
                    {
                        if (item.Equals(category))
                        {
                            customers.Add(entry.Customer);
                        }
                    }
                }
                return customers;
            }
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
