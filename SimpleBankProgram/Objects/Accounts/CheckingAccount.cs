using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankProgram.Objects
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string owner) : base(owner, AccountType.Checking)
        {

        }

        // open account with initial balance != 0
        public CheckingAccount(string owner, double initialBalance) : base(owner, initialBalance, AccountType.Checking)
        {

        }
    }
}
