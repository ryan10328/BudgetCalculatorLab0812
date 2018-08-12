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
                var budget = budgets[0];
                return budget.EffectiveAmount(period);
            }
            
            return 0;
        }
    }
}