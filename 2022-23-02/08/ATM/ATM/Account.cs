using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Account
    {
        public int Balance { get; private set; }
        public readonly string AccountNo;
        public List<Card> cards = new ();

        public Account(string no) { AccountNo = no; Balance = 0; }

        public void AddCard(Card card) { cards.Add(card); }

        public void Modify(int a) { Balance += a; }

        public bool CardSearch(string cardNo)
        {
            foreach (Card card in cards)
            {
                if (card.cardNo == cardNo) return true;
            }
            return false;
        }
    }
}
