using System;
using System.Collections.Generic;

namespace ATM
{
    class Customer
    {
        public class NoCardException : Exception {};
        
        public readonly string name;
        private readonly string pin;    // pinkód
        private readonly List<Card> cards = new ();
        private int needMoney;

        public Customer( string name, string pin) { this.name = name; this.pin = pin; }
        public void Withdraw(ATM atm) { atm.Process(this); }
        public void TakeCard(Card card) { cards.Add(card); }
        public void NeedMoney(int m) { needMoney = m; }               
        public Card GiveCard() 
        { 
            if (cards.Count>0) return cards[0]; 
            else throw new NoCardException(); 
        }
        public string GivePin() { return pin; }
        public int AskMoney() { return needMoney; }
    }
}
