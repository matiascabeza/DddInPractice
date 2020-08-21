using System;
using DddInPratice.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DddInPratice.Logic.Money;

namespace DddInPraticeUnitTest
{
    [TestClass]
    public class SnackMachineSpecs
    {
        [TestMethod]
        public void Return_money_empties_money_in_transaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);

            snackMachine.ReturnMoney();

            Assert.AreEqual(snackMachine.MoneyInTransaction.Amount, 0.00M);
        }

        [TestMethod]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            Assert.AreEqual(snackMachine.MoneyInTransaction.Amount, 1.01m);
        }

        [TestMethod]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Money_in_transaction_goes()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack();

            Assert.AreEqual(snackMachine.MoneyInTransaction, None);
            Assert.AreEqual(snackMachine.MoneyInside.Amount, 2m);
        }


    }
}
