namespace Task3
{
    abstract class Citizen
    {
        public string Name { get; }
        public string LastName { get; }
        public string Passport { get; }

        public Citizen(string name, string lastName, string passport)
        {
            Name = name;
            LastName = lastName;
            Passport = passport.ToLower();
        }

        public override bool Equals(object obj)
        {
            if (obj as Citizen != null)
            {
                return ((Citizen)obj).Passport == this.Passport;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int p = Name.GetHashCode();
            int n = LastName.GetHashCode();
            int l = Passport.GetHashCode();
            return 2 * p ^ 4 * n ^ 7 * l;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} {LastName}";
        }
    }
}
