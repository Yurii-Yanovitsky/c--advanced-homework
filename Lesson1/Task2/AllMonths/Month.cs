using System;

namespace Task2.AllMonths
{
    abstract class Month
    {
        public int Number { get; }
        public int Days { get; }

        protected Month(int number)
        {
            Number = number;
            Days = DateTime.DaysInMonth(DateTime.Now.Year, number);
        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
