using System;

namespace awesomeProject
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to The Amazing Vending Machine. What's your name?");
            var name = Console.ReadLine();
            var user = new User(name);
            var vendingMachine = new VendingMachine();
            var bank = new Bank(200);
            
            Console.WriteLine();
            Console.WriteLine($"Welcome {user.Name}. If you want to buy something you'll need some cash.");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Go to the bank.");
                Console.WriteLine("2. Buy a drink from The Amazing Vending Machine.");
                Console.WriteLine("3. Check your pockets for cash.");
                Console.WriteLine("4. List the items in your bag.");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Welcome to the bank.");

                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("1. See how much money I've got on my bankaccount.");
                            Console.WriteLine("2. Withdraw cash.");
                            Console.WriteLine("3. Go back.");

                            var option = Console.ReadLine();

                            if (option == "1")
                            {
                                bank.ShowBalance();
                                continue;
                            }

                            if (option == "2")
                            {
                                Console.WriteLine();
                                Console.WriteLine("How much would you like to withdraw?");
                                int.TryParse(Console.ReadLine(), out int amount);
                                var cash = bank.Withdraw(amount);
                                user.GetCash(cash);
                                continue;
                            }

                            if (option == "3") break;
                        }
                        break;

                    case "2":
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter the number of the product you want.");
                            vendingMachine.ShowList();
                            var input = Console.ReadLine();
                            var item = vendingMachine.Shop(input, user.Cash);

                            if (item == null) break;

                            user.RemoveCash(item.Price);
                            user.AddItemToBag(item);

                            Console.WriteLine();
                            Console.WriteLine("Anything else?");
                            Console.WriteLine("1. Yes please.");
                            Console.WriteLine("2. No, I want to go back.");
                            var answer = Console.ReadLine();

                            if (answer == "1") continue;

                            if (answer == "2") break;
                        }
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine($"You've got {user.Cash}kr in your pocket.");
                        break;

                    case "4":
                        user.CheckBag();
                        break;
                }
            }
        }
    }
}