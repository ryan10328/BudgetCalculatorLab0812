using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BudgetCalculatorAdv.Tests
{
    [TestClass]
    public class BudgetCalculatorTests
    {
        private BudgetCalculator _calculator;
        private IBudgetRepository _budgetRepository = Substitute.For<IBudgetRepository>();

        [TestInitialize]
        public void Setup()
        {
            _calculator = new BudgetCalculator(_budgetRepository);
        }

        /// <summary>
        /// period: 20180301 to 20180301
        /// expected amount: 0
        /// </summary>
        [TestMethod]
        public void NoBudget()
        {
            _budgetRepository.GetAll().Returns(new List<Budget>());
            TotalAmountShouldBe("20180301", "20180301", 0);
        }

        /// <summary>
        /// period: 20180301 to 20180301
        /// expected amount: 0
        /// </summary>
        [TestMethod]
        public void Period_Inside_BudgetMonth()
        {
            _budgetRepository.GetAll().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201803",
                    Amount = 31
                }
            });
            TotalAmountShouldBe("20180301", "20180301", 1);
        }

        [TestMethod]
        public void No_Overlap_Period_AfterBudgetLastDay()
        {
            _budgetRepository.GetAll().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201803",
                    Amount = 31
                }
            });
            TotalAmountShouldBe("20180401", "20180401", 0);
        }


        private void TotalAmountShouldBe(string start, string end, decimal expected)
        {
            var startDate = DateTime.ParseExact(start, "yyyyMMdd", null);
            var endDate = DateTime.ParseExact(end, "yyyyMMdd", null);
            var actual = _calculator.TotalAmount(startDate, endDate);
            Assert.AreEqual(expected, actual);
        }
    }
}