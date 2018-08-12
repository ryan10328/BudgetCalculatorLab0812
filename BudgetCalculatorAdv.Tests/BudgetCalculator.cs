using System;
using System.Linq;

namespace BudgetCalculatorAdv.Tests
{
    public class BudgetCalculator
    {
        private IBudgetRepository _budgetRepository;
        public BudgetCalculator(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        
        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepository.GetAll();

            if (budgets.Any())
            {
                return (end - start).Days + 1;
            }
            
            return 0;
        }
    }
}