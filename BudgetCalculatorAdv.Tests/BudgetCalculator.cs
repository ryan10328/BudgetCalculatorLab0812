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
            var period = new Period(start, end);

            if (budgets.Any())
            {
                if (period.End < budgets[0].StartDay)
                {
                    return 0;
                }
                
                if (period.Start > budgets[0].LastDay)
                {
                    return 0;
                }
                
                return period.Days();
            }
            
            return 0;
        }
    }
}