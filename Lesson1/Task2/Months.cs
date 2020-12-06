using System.Collections.Generic;
using Task2.AllMonths;

namespace Task2
{
    class Months
    {
        private Month[] months;
        public Months()
        {
            months = new Month[]
            {
                new January(1),
                new February(2),
                new March(3),
                new April(4),
                new May(5),
                new June(6),
                new July(7),
                new August(8),
                new September(9),
                new October(10),
                new November(11),
                new December(12)
             };
        }

        public IEnumerable<Month> GetMonthByNumber(int number)
        {
            foreach (var month in months)
            {
                if (number == month.Number)
                {
                    yield return month;
                }
            }
        }
        public IEnumerable<Month> GetMonthByDays(int days)
        {
            foreach (var month in months)
            {
                if (days == month.Days)
                {
                    yield return month;
                }
            }
        }
    }
}
