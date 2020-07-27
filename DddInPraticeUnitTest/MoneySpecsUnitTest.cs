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
        public void Cannot_create_money_with_negative_value(int oneCentCount,
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
    }
}
