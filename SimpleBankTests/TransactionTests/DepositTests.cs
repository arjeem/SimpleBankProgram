using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBankProgram.Objects;
using SimpleBankProgram.Data;
using System;

namespace SimpleBankTests
{
    [TestClass]
    public class DepositTests
    {
        [TestMethod]
        public void Deposit_WithValidAmount_BalanceUpdated()
        {
            // Arrange
            CheckingAccount checkingAccount = new CheckingAccount("Arjee M");
            double expectedBalance = 500.00;

            // Act
            Transactions.Deposit(500.00, checkingAccount);

            // Assert
            double actualBalance = checkingAccount.getBalance();
            Assert.AreEqual(expectedBalance, actualBalance, 0.001, $"Actual Balance ({actualBalance}) not equal to expected balance of {expectedBalance}.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
             "Was allowed to deposit negative amount")]
        public void Deposit_WithInvalidAmount_ExceptionThrown()
        {
            // Arrange
            CheckingAccount checkingAccount = new CheckingAccount("Arjee M");

            // Act
            Transactions.Deposit(-500.00, checkingAccount);
        }

    }
}
