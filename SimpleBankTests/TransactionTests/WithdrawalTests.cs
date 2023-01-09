using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBankProgram.Objects;
using SimpleBankProgram.Data;
using System;

namespace SimpleBankTests
{
    [TestClass]
    public class WithdrawalTests
    {
        [TestMethod]
        public void Withdrawal_CheckingAccount_WithValidAmount_BalanceUpdated()
        {
            // Arrange
            CheckingAccount checkingAccount = new CheckingAccount("Arjee M", 500.00);
            double expectedBalance = 350.50;

            // Act
            Transactions.Withdrawal(149.50, checkingAccount);

            // Assert
            double actualBalance = checkingAccount.getBalance();
            Assert.AreEqual(expectedBalance, actualBalance, 0.001, $"Actual Balance ({actualBalance}) not equal to expected balance of {expectedBalance}.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Was allowed to withdraw negative amount")]
        public void Withdrawal_CheckingAccount_WithInvalidAmount_ExceptionThrown()
        {
            // Arrange
            CheckingAccount checkingAccount = new CheckingAccount("Arjee M");

            // Act
            Transactions.Withdrawal(-500.00, checkingAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Was allowed withdraw more than balance")]
        public void Withdrawal_CorporateInvestmentAccount_OverBalanceAmount_ExceptionThrown()
        {
            // Arrange
            InvestmentAccount corporateAccount = new InvestmentAccount("Arjee M", 900.00, InvestmentAccountType.Corporate);

            // Act
            Transactions.Withdrawal(1000.00, corporateAccount);
        }

        [ExpectedException(typeof(Exception),
            "Was allowed to exceed withdrawal limit")]
        public void Withdrawal_IndividualInvestmentAccount_OverWithdrawalLimit_ExceptionThrown()
        {
            // Arrange
            InvestmentAccount corporateAccount = new InvestmentAccount("Arjee M", 1000.00, InvestmentAccountType.Individual);

            // Act
            Transactions.Withdrawal(500.01, corporateAccount);
        }

    }
}
