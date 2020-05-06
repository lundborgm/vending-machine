using System;

namespace awesomeProject
{
    public class Bank
    {
        private int Account { get; set; }

        public Bank(int account)
        {
            Account = account;
        }

        public int Withdraw(int amount)
        {
            if (Account < amount)
            {
                Console.WriteLine();
                Console.WriteLine("Sorry, there's not enough money on your bank account, try a lower amount.");
                return 0;
            }

            Account -= amount;
            Console.WriteLine();
            Console.WriteLine("Withdrawal sucessful!");
            return amount;
        }
        
        public void ShowBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"You got {Account}kr on your bank account.");
        }
    }
}