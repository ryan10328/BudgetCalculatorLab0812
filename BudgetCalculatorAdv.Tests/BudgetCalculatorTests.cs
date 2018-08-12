using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetCalculatorAdv.Tests
{
    [TestClass]
    public class BudgetCalculatorTests
    {
        /// <summary>
        /// period: 20180301 to 20180301
        /// expected amount: 0
        /// </summary>
        [TestMethod]
        public void NoBudget()
        {
            var sut = new BudgetCalculator();
            var startDate = DateTime.ParseExact("20180301", "yyyyMMdd", null);
            var endDate = DateTime.ParseExact("20180301", "yyyyMMdd", null);
            var actual = sut.TotalAmount(startDate, endDate);
            Assert.AreEqual(0, actual);
        }

    }
}