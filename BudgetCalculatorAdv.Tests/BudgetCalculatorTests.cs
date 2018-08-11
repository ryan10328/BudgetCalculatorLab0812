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
            var actual = sut.TotalAmount("20180301", "20180301");
            Assert.AreEqual(0, actual);
        }
    }
}