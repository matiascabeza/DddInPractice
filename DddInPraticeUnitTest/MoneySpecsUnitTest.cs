using System;
using DddInPratice.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DddInPraticeUnitTest
{
    [TestClass]
    public class MoneySpecsUnitTest
    {
        [TestMethod]
        public void Sum_of_two_money_produces_correct_result()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = money1 + money2;

            Assert.AreEqual(2, sum.OneCentCount);
            Assert.AreEqual(4, sum.TenCentCount);
            Assert.AreEqual(6, sum.QuarterCount);
            Assert.AreEqual(8, sum.OneDollarCount);
            Assert.AreEqual(10, sum.FiveDollarCount);
            Assert.AreEqual(12, sum.TwentyDollarCount);
        }

        [TestMethod]
        public void two_money_instances_equal_if_contain_the_same_money_amount()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Assert.AreEqual(money1.OneCentCount, money2.OneCentCount);
            Assert.AreEqual(money1.TenCentCount, money2.TenCentCount);
            Assert.AreEqual(money1.QuarterCount, money2.QuarterCount);
            Assert.AreEqual(money1.OneDollarCount, money2.OneDollarCount);
            Assert.AreEqual(money1.FiveDollarCount, money2.FiveDollarCount);
            Assert.AreEqual(money1.TwentyDollarCount, money2.TwentyDollarCount);
        }
        [TestMethod]
        public void two_money_instances_do_not_equal_if_contain_different_money_amounts()
        {
            Money dollar = new Money(0, 0, 0, 1, 0, 0);
            Money hundredCents = new Money(100, 0, 0, 0, 0, 0);

            Assert.AreNotEqual(dollar.OneCentCount, hundredCents.OneCentCount);
        }

        [TestMethod]
        [DataRow(-1,0,0,0,0,0)]
        [DataRow(0,-2,0,0,0,0)]
        [DataRow(0,0,-3,0,0,0)]
        [DataRow(0,0,0,-4,0,0)]
        [DataRow(0,0,0,0,-5,0)]
        [DataRow(0,0,0,0,0,-6)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            try
            {
                Action action = () => new Money(
                  oneCentCount,
                  tenCentCount,
                  quarterCount,
                  oneDollarCount,
                  fiveDollarCount,
                  twentyDollarCount);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex, nameof(InvalidOperationException));
            }
        }

        [TestMethod]
        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataRow(1, 0, 0, 0, 0, 0, 0.01)]
        [DataRow(1, 2, 0, 0, 0, 0, 0.21)]
        [DataRow(1, 2, 3, 0, 0, 0, 0.96)]
        [DataRow(1, 2, 3, 4, 0, 0, 4.96)]
        [DataRow(1, 2, 3, 4, 5, 0, 29.96)]
        [DataRow(1, 2, 3, 4, 5, 6, 149.96)]
        [DataRow(11, 0, 0, 0, 0, 0, 0.11)]
        [DataRow(110, 0, 0, 0, 100, 0, 501.1)]
        public void Amount_is_calculated_correctly(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            double expectedAmount)
        {
            Money money = new Money(
                  oneCentCount,
                  tenCentCount,
                  quarterCount,
                  oneDollarCount,
                  fiveDollarCount,
                  twentyDollarCount);

            Assert.AreEqual(money.Amount, decimal.Parse(expectedAmount.ToString()));
        }

       
        [TestMethod]
        public void Substraction_of_two_moneys_produces_correct_result()
        {
            Money money1 = new Money(10, 10, 10, 10, 10, 10);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money result = money1 - money2;
            Assert.AreEqual(result.OneCentCount,9);
            Assert.AreEqual(result.TenCentCount, 8);
            Assert.AreEqual(result.QuarterCount, 7);
            Assert.AreEqual(result.OneDollarCount, 6);
            Assert.AreEqual(result.FiveDollarCount, 5);
            Assert.AreEqual(result.TwentyDollarCount, 4);

        }

        [TestMethod]

        public void Cannot_subtract_more_than_exists()
        {
            Money money1 = new Money(0, 1, 0, 0, 0, 0);
            Money money2 = new Money(1, 0, 0, 0, 0, 0);

            Action action = () => { Money money = money1 - money2; };

            Assert.ThrowsException<InvalidOperationException>(action);

        }
    }
}
