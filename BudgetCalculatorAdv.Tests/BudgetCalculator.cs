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

            if (budgets.Any())
            {
                var totalAmount = 0m;
                foreach (var budget in budgets)
                {
                    totalAmount += budget.EffectiveAmount(period);
                }
                return totalAmount;
            }

            return 0;
        }
    }
}