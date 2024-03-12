using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Card
    {
        public string bankCode;
        public string cardNo;
        private string pinCode;
        public Customer customer;

        public Card( Customer customer, string bankCode, string cardNo, string pinCode)
        { 
            this.customer = customer; this.bankCode = bankCode; this.cardNo = cardNo; this.pinCode = pinCode;  
        }

        public bool PinCheck(string pin) 
        { 
            return pin == pinCode;
        }

        public void ChangePin(string oldpin, string pin) 
        {
            if(oldpin==pinCode) pinCode = pin;
        }

        public string GetBankCode() 
        { 
            return bankCode; 
        }
    }
}
