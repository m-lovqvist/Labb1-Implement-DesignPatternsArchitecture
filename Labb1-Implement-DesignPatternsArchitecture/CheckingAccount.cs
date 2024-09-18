using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implement_DesignPatternsArchitecture
{
    // Inherits from Account and implements unique behaviors for deposit and withdrawal.
    public class CheckingAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Notify();
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Notify();
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }
}
