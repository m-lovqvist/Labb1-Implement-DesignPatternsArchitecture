using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implement_DesignPatternsArchitecture
{
    // Factory Method pattern to create different types of accounts.
    // This allows accounts to be created without knowing the specific class being instantiated.
    public static class AccountFactory
    {
        public static Account CreateAccount(string type, string accountNumber)
        {
            switch (type.ToLower())
            {
                case "savings":
                    return new SavingsAccount { AccountNumber = accountNumber };
                case "checking":
                    return new CheckingAccount { AccountNumber = accountNumber };
                case "external":
                    return new ExternalBankAPIAdapter(accountNumber);
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
    }
}
