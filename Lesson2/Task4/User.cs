using System.Collections;

namespace Task4
{
    class User : IEqualityComparer
    {
        public string Name { get; }
        public string LastName { get; }
        public int ID { get; }

        public User(string name, string lastName, int id)
        {
            Name = name;
            LastName = lastName;
            ID = id;
        }
        public User()
        {

        }

        public new bool Equals(object x, object y)
        {
            if (x is User a && y is User b)
            {
                return a.ID == b.ID;
            }
            return false;
        }

        public int GetHashCode(object obj)
        {
            if (obj is User a)
            {
                return a.ID;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"ID{ID}";
        }
    }
}
