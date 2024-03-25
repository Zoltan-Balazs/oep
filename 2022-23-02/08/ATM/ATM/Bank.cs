using System;
using System.Collections.Generic;

namespace ATM
{
    class Bank
    {
        public class IllegalTransaction : Exception { }

        public string code;
        private readonly List<Account> accounts = new();
        private readonly List<Customer> customers = new();

        public class NonExistingAccountException : Exception { };

        public Bank(string c)
        {
            code = c;
        }

        public Account CreateAccount(Customer customer, string accountNo)
        {
            Account acc = new(accountNo);
            customers.Add(customer);
            accounts.Add(acc);

            return acc;
        }

        public Card CreateCard(Customer customer, Account account, string cardNo, string pin)
        {
            if (null == account)
                throw new NonExistingAccountException();
            if (!customers.Contains(customer))
                throw new IllegalTransaction();
            Card card = new(customer, code, cardNo, pin);
            account.AddCard(card);
            return card;
        }

        public int GetBalance(string cardNo)
        {
            Account account = AccountSearch(cardNo);
            if (null == account)
                throw new NonExistingAccountException();
            return account.Balance;
        }

        public void Transaction(string cardNo, int a)
        {
            Account account = AccountSearch(cardNo);
            if (null == account)
                throw new NonExistingAccountException();
            account.Modify(a);
        }

        public Account AccountSearch(string cardNo)
        {
            foreach (Account acc in accounts)
            {
                if (acc.CardSearch(cardNo))
                    return acc;
            }
            return null;
        }
    }
}
