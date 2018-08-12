using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetCalculatorAdv.Tests
{
    [TestClass]
    public class BudgetCalculatorTests
    {
        private BudgetCalculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new BudgetCalculator();
        }

        /// <summary>
        /// period: 20180301 to 20180301
        /// expected amount: 0
        /// </summary>
        [TestMethod]
        public void NoBudget()
        {
            TotalAmountShouldBe("20180301", "20180301", 0);
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