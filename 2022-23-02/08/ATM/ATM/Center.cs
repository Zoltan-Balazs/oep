using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Center
    {
        public class BankNotFoundException : Exception { }

        private readonly List<Bank> banks = new();

        public void Registrates(Bank bank)
        {
            banks.Add(bank);
        }

        public int GetBalance(string bankCode, string cardNo)
        {
            return BankSearch(bankCode).GetBalance(cardNo);
        }

        public void Transaction(string bankCode, string cardNo, int a)
        {
            BankSearch(bankCode).Transaction(cardNo, a);
        }

        private Bank BankSearch(string bankCode)
        {
            foreach (Bank bank in banks)
            {
                if (bank.code == bankCode)
                    return bank;
            }
            return null;
        }
    }
}
