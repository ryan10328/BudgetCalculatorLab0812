using System;
using System.Linq;

namespace BudgetCalculatorAdv.Tests
{
    public class BudgetCalculator
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetCalculator(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepository.GetAll();
            var period = new Period(start, end);
            return budgets.Any() ? budgets.Sum(budget => budget.EffectiveAmount(period)) : 0;
        }
    }
}