using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBankProgram.Objects;
using SimpleBankProgram.Data;
using System;


namespace SimpleBankTests
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void Transfer_CheckingtoCheckingAccount_WithValidAmount_BalanceUpdated()
        {
            // Arrange
            CheckingAccount fromAccount = new CheckingAccount("Arjee M", 500.00);
            CheckingAccount toAccount = new CheckingAccount("Arjee N", 400.00);
            double expectedToBalance = 600.50;
            double expectedFromBalance = 299.50;

            // Act
            Transactions.Transfer(200.50, fromAccount, toAccount);

            // Assert
            double actualFromBalance = fromAccount.getBalance();
            double actualToBalance = toAccount.getBalance();
            Assert.AreEqual(expectedFromBalance, actualFromBalance, 0.001, $"Actual fromAccount Balance ({actualFromBalance}) not equal to expected balance of {expectedFromBalance}.");
            Assert.AreEqual(expectedToBalance, actualToBalance, 0.001, $"Actual toAccount Balance ({actualFromBalance}) not equal to expected balance of {expectedFromBalance}.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Was allowed to transfer negative amount")]
        public void Transfer_CheckingtoCheckingAccount_WithInvalidAmount_ExceptionThrown()
        {
            // Arrange
            CheckingAccount fromAccount = new CheckingAccount("Arjee M", 500.00);
            CheckingAccount toAccount = new CheckingAccount("Arjee N", 400.00);

            // Act
            Transactions.Transfer(-200.50, fromAccount, toAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Was allowed to transfer more than amount in fromAccount")]
        public void Transfer_CheckingtoCheckingAccount_OverBalanceWithdrawal_ExceptionThrown()
        {
            // Arrange
            CheckingAccount fromAccount = new CheckingAccount("Arjee M", 500.00);
            CheckingAccount toAccount = new CheckingAccount("Arjee N", 400.00);

            // Act
            Transactions.Transfer(1000.50, fromAccount, toAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Was allowed to transfer more than withdrawalLimit in fromAccount")]
        public void Transfer_IndividualtoCheckingAccount_OverBalanceWithdrawal_ExceptionThrown()
        {
            // Arrange
            InvestmentAccount fromAccount = new InvestmentAccount("Arjee M", 1000.00, InvestmentAccountType.Individual);
            CheckingAccount toAccount = new CheckingAccount("Arjee N", 400.00);

            // Act
            Transactions.Transfer(500.01, fromAccount, toAccount);
        }

    }
}
