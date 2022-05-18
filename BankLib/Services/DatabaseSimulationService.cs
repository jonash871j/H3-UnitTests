using BankLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankLib.Services
{
    public interface IDatabaseSimulationService
    {
        bool IsPinValid(int acountId, int pin);
        int TakeMoneyFromAccount(int accountId, int money);
    }

    // This class simulates stored procedures being called
    public class DatabaseSimulationService : IDatabaseSimulationService
    {
        private List<Account> accountTable = new List<Account>()
        {
            new Account
            {
                Id = 1,
                Money = 30000,
                Pin = 1234,
            }
        };

        public bool IsPinValid(int accountId, int pin)
        {
            return accountTable.FindAll(a => a.Id == accountId)
                .SingleOrDefault().Pin == pin;
        }

        public int TakeMoneyFromAccount(int accountId, int money)
        {
            Account account = accountTable.FindAll(a => a.Id == accountId).SingleOrDefault();
            if (account == null)
            {
                return 0;
            }
            if (account.Money >= money)
            {
                account.Money -= money;
            }
            return money;
        }
    }
}
