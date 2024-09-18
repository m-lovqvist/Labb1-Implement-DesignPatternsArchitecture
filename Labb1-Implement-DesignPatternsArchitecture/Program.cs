using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implement_DesignPatternsArchitecture
{
    internal class Program
    {
        // This application implements the following design patterns:
        // 1. Singleton: Used in the ATMSystem class to ensure that only one instance of the system exists.
        // 2. Factory Method: Used in the AccountFactory class to create different types of accounts.
        // 3. Adapter: Used in the ExternalBankAPIAdapter class to adapt an external bank API to the Account interface.

        static void Main(string[] args)
        {
            ATMSystem atmSystem = ATMSystem.Instance;

            // Creating accounts using Factory Method
            Account savings = AccountFactory.CreateAccount("savings", "S123");
            Account checking = AccountFactory.CreateAccount("checking", "C123");
            Account external = AccountFactory.CreateAccount("external", "EXT123");

            atmSystem.AddAccount(savings);
            atmSystem.AddAccount(checking);
            atmSystem.AddAccount(external);

            while (true)
            {
                Console.WriteLine("Mini's ATM");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Please choose an option: ");
                var choice = Console.ReadLine();

                if (choice == "4") break;

                Console.Write("Enter account number: ");
                var accountNumber = Console.ReadLine();
                var account = atmSystem.GetAccount(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Invalid account number.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                            Console.WriteLine($"Deposited {depositAmount} to account {accountNumber}. New balance: {account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine($"Withdrew {withdrawAmount} from account {accountNumber}. New balance: {account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Current balance: {account.Balance}");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.WriteLine();
            }
        }
    }
}
