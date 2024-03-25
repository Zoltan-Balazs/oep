using System;

namespace ATM
{
    class ATM
    {
        public class FewMoneyException : Exception { }

        public class WrongPinCodeException : Exception { }

        public readonly string location;
        private readonly Center center;

        public ATM(string location, Center center)
        {
            this.location = location;
            this.center = center;
        }

        public void Process(Customer cust)
        {
            Card card = cust.GiveCard();
            if (card.PinCheck(cust.GivePin()))
            {
                int a = cust.AskMoney();
                if (center.GetBalance(card.bankCode, card.cardNo) >= a)
                {
                    center.Transaction(card.bankCode, card.cardNo, -a);
                }
                else
                    throw new FewMoneyException();
            }
            else
                throw new WrongPinCodeException();
        }
    }
}
