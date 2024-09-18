using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implement_DesignPatternsArchitecture
{
    // This is a fictitious external bank API that represents an external system.
    public class ExternalBankAPI
    {
        public decimal GetBalance(string accountNumber)
        {
            return 2000.0m;
        }

        public void MakeDeposit(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Deposit of {amount} made to account {accountNumber} in a external system.");
            Console.WriteLine();
        }

        public void MakeWithdrawal(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Withdrawal of {amount} made from account {accountNumber} in a external system.");
            Console.WriteLine();
        }
    }
}
