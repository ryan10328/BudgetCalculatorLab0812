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

        public int Days()
        {
            return (End - Start).Days + 1;
        }
    }
}