using System;

namespace BudgetCalculatorAdv.Tests
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(int.Parse(YearMonth.Substring(0, 4)), int.Parse(YearMonth.Substring(4, 2)));
                return DateTime.ParseExact($"{YearMonth}{daysInMonth}", "yyyyMMdd", null);
            }
        }

        public DateTime StartDay => DateTime.ParseExact($"{YearMonth}01", "yyyyMMdd", null);
    }
}