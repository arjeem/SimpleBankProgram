using System;

namespace SimpleBankProgram.Objects
{
    public enum AccountType
    {
        Checking = 1,
        Investment = 2
    }

    // abstract so created accounts must be either investment or checking
    public abstract class BankAccount
    {
        private string Owner;
        private double Balance;
        private AccountType AccountType;
        private double WithdrawalLimit;

        public BankAccount(string ownerName, AccountType accountType)
        {
            Owner = ownerName;
            AccountType = accountType;
            Balance = 0.00;
            WithdrawalLimit = -1;
        }

        // open account with initial balance != 0
        public BankAccount(string ownerName, double initialBalance, AccountType accountType)
        {
            Owner = ownerName;
            AccountType = accountType;
            Balance = initialBalance;
            WithdrawalLimit = -1;
        }

        public string GetOwner()
        {
            return Owner;
        }

        public void setOwner(string owner)
        {
            Owner = owner;
        }

        public double getBalance()
        {
            return Balance;
        }

        public void setBalance(double balance)
        {
            Balance = balance;
        }

        public AccountType GetAccountType()
        {
            return AccountType;
        }

        public void SetAccountType(AccountType accountType)
        {
            AccountType = accountType;
        }

        public double GetWithdrawalLimit()
        {
            return WithdrawalLimit;
        }

        public void SetWithdrawalLimit(double withdrawalLimit)
        {
            if (withdrawalLimit > 0)
            {
                WithdrawalLimit = withdrawalLimit;
            }
            else
            {
                throw new Exception("Can not set withdrawal limit at zero or less.");
            }
        }
    }
}
