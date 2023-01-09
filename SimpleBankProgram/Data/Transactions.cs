using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankProgram.Objects;

namespace SimpleBankProgram.Data
{
    public static class Transactions
    {
        // deposit to bankaccount
        public static void Deposit(double depositAmount, BankAccount bankAccount)
        {
            // check deposit amount
            if(depositAmount < 0.0)
            {
                throw new Exception("Must deposit positive amount");
            }

            double newBalance = bankAccount.getBalance() + depositAmount;
            bankAccount.setBalance(newBalance);
        }

        // withdraw from bankaccount
        public static void Withdrawal(double withdrawalAmount, BankAccount bankAccount)
        {
            // check withdrawal amount
            if (withdrawalAmount < 0.0)
            {
                throw new Exception("Must withdraw positive amount");
            }

            // check withdrawal limits
            double accountWithdrawalLimit = bankAccount.GetWithdrawalLimit();
            // if not -1, withdrawal limit has been set, but cannot withdraw less than 1 cent
            if (accountWithdrawalLimit > 0.00)
            {
                // Exceeded withdrawal limit
                if (withdrawalAmount > accountWithdrawalLimit)
                {
                    throw new Exception($"Withdrawal limit of ${accountWithdrawalLimit} exceeded.");
                }
            }

            // attempt withdrawal
            if(withdrawalAmount > bankAccount.getBalance())
            {
                throw new Exception("Cannot withdraw more than balance.");
            }

            double newBalance = bankAccount.getBalance() - withdrawalAmount;
            bankAccount.setBalance(newBalance);
        }

        // withdraw from account to deposit into other
        public static void Transfer(double transferAmount, BankAccount fromAccount, BankAccount toAccount)
        {
            try
            {
                Withdrawal(transferAmount, fromAccount);
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed withdrawl from account owned by {fromAccount.GetOwner()} due to following: {ex.Message}");
            }

            try
            {
                Deposit(transferAmount, toAccount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed deposit to account owned by {fromAccount.GetOwner()} due to following: {ex.Message}");
            }

        }

    }
}
