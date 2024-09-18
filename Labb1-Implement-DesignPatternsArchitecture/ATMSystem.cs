using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implement_DesignPatternsArchitecture
{
    // Singleton pattern to ensure that only one instance of ATMSystem exists.
    public class ATMSystem
    {
        private static ATMSystem _instance;
        private static readonly object _lock = new object();
        private List<Account> _accounts = new List<Account>();

        private ATMSystem()
        {

        }

        public static ATMSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ATMSystem();
                }
                return _instance;
            }
        }
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(string accountNumber)
        {
            return _accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
