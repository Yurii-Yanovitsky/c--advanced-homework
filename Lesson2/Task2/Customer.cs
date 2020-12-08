namespace Task2
{
    public class Customer
    {
        public string Name { get; }
        public int ID { get; }

        public Customer(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Customer customer)
            {
                return ID == customer.ID;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
