using System;

namespace BudgetCalculatorAdv.Tests
{
    public class Period
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public Period(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException();
            }
            
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
            var effectiveStart = budget.StartDay > Start ? budget.StartDay : Start;
            return (effectiveEnd - effectiveStart).Days + 1;
        }

        private bool HasNoOverlapping(Budget budget)
        {
            return End < budget.StartDay || Start > budget.LastDay;
        }
    }
}