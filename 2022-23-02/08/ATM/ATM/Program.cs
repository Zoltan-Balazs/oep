using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            Center center = new ();
            Bank otp = new ("otp");                         // bankcode is given
            center.Registrates(otp);

            Customer customer = new ("Joe", "1234");        // Joe's usual PIN code is 1234 

            Account account = otp.CreateAccount(customer, "otp1001"); // new account has been created for Joe
            account.Modify(100000);                         // 100000 Forints has been deposited into Joe's account

            Card card = otp.CreateCard(customer, account, "otpcard1001", "0000");   // Joe's credit card has been created       
            customer.TakeCard(card);                        // Joe has got his credit card
            card.ChangePin("0000", "1234");                 // Joe has changed the PIN code of his card

            Console.WriteLine($"Old balance: {account.Balance}"); 
            
            customer.NeedMoney(50000);                      // Joe needs money
            ATM atm = new ("somewhere", center);            // Joe has found an ATM
            customer.Withdraw(atm);                         // Joe has withdrawn money
            Console.WriteLine($"New balance: {account.Balance}");
        }
    }
}
