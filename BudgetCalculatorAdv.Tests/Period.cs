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

        public decimal OverlappingDays(Period period)
        {
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            var effectiveEnd = period.End < End ? period.End : End;
            var effectiveStart = period.Start > Start ? period.Start : Start;
            return (effectiveEnd - effectiveStart).Days + 1;
        }

        private bool HasNoOverlapping(Period period)
        {
            return End < period.Start || Start > period.End;
        }
    }
}