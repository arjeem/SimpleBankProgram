using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankProgram.Objects
{
    class Bank
    {
        private string Name;
        private List<BankAccount> bankAccounts;

        public Bank(string name)
        {
            Name = name;
            bankAccounts = new List<BankAccount>();
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
        }
    }
}
