using System;

namespace BudgetCalculatorAdv.Tests
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime EndDay => DateTime.ParseExact($"{YearMonth}{DaysInMonth}", "yyyyMMdd", null);
        public DateTime StartDay => DateTime.ParseExact($"{YearMonth}01", "yyyyMMdd", null);
        public int DaysInMonth => DateTime.DaysInMonth(int.Parse(YearMonth.Substring(0, 4)), int.Parse(YearMonth.Substring(4, 2)));

        public decimal DailyAmount()
        {
            return Amount / DaysInMonth;
        }

        public decimal EffectiveAmount(Period period)
        {
            return period.OverlappingDays(CreatePeriod()) * DailyAmount();
        }

        private Period CreatePeriod()
        {
            return new Period(StartDay, EndDay);
        }
    }
}