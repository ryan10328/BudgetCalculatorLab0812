using System;

namespace BudgetCalculatorAdv.Tests
{
    public class Period
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public decimal OverlappingDays(Budget budget)
        {
            if (HasNoOverlapping(budget))
            {
                return 0;
            }

            var effectiveEnd = budget.LastDay < End ? budget.LastDay : End;

            return (effectiveEnd - Start).Days + 1;
        }

        private bool HasNoOverlapping(Budget budget)
        {
            return End < budget.StartDay || Start > budget.LastDay;
        }
    }
}