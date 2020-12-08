using System;
using System.Collections.Generic;

namespace Task2
{
    public class Entry
    {
        public Customer Customer { get; }
        public List<Category> Products { get; }

        public Entry(Customer customer, Category product)
        {
            Products = new List<Category>();
            Customer = customer;
            AddProduct(product);
        }

        private void AddProduct(Category product)
        {
            if (!Products.Contains(product))
            {
                Products.Add(product);
            }
        }

        public override string ToString()
        {
            string str = "";
            Products.ForEach((x) => str += Enum.GetName(typeof(Category), x) + ", ");


            return $"{Customer.Name}: {str.TrimEnd(',', ' ')}";
        }
    }
}
