using BankLib.Expcetions;
using System;

namespace BankLib.Services
{
    public interface IATMService
    {
        int WithdrawMoney(int accountId, int pin, int money);
    }

    public class ATMService : IATMService
    {
        private readonly IDatabaseSimulationService databaseSimulationService;

        public ATMService(IDatabaseSimulationService databaseSimulationService)
        {
            this.databaseSimulationService = databaseSimulationService;
        }

        public int WithdrawMoney(int accountId, int pin, int money)
        {
            if (money <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(money));
            }
            if (!databaseSimulationService.IsPinValid(accountId, pin))
            {
                throw new InvalidPinException();
            }

            int withdrawedMoney = databaseSimulationService.TakeMoneyFromAccount(accountId, money);
            if (withdrawedMoney == 0)
            {
                throw new NotEnoughMoneyException();
            }

            return withdrawedMoney;
        }
    }
}
