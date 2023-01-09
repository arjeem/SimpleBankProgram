using System;
using SimpleBankProgram.Objects;

namespace SimpleBankProgram.Objects
{
    public enum InvestmentAccountType
    {
        Individual = 1,
        Corporate = 2
    }

    public class InvestmentAccount : BankAccount
    {
        private InvestmentAccountType InvestmentAccountType;
        

        public InvestmentAccount(string owner, InvestmentAccountType accountType) : base(owner, Objects.AccountType.Investment)
        {
            InvestmentAccountType = accountType;

            if (accountType == InvestmentAccountType.Individual)
            {
                base.SetWithdrawalLimit(500.00);
            }
        }

        // open account with initial balance != 0
        public InvestmentAccount(string owner, double initialBalance, InvestmentAccountType accountType) : base(owner, initialBalance, Objects.AccountType.Investment)
        {
            InvestmentAccountType = accountType;

            if (accountType == InvestmentAccountType.Individual)
            {
                base.SetWithdrawalLimit(500.00);
            }
        }

        public InvestmentAccountType GetInvestmentAccountType()
        {
            return InvestmentAccountType;
        }

        public void SetInvestmentAccountType(InvestmentAccountType investmentAccountType)
        {
            InvestmentAccountType = investmentAccountType;
        }
    }
}
