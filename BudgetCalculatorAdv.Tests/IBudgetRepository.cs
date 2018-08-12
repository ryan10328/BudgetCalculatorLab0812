using System.Collections.Generic;

namespace BudgetCalculatorAdv.Tests
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
    }
}