using System;
using System.Collections.Generic;
using System.Net;

namespace awesomeProject
{
    public class VendingMachine
    {
        private readonly List<Item> itemsList = new List<Item>
        {
            new Item("Beer", 40),
            new Item("Coffee", 30),
            new Item("Tea", 25),
            new Item("Water", 20),
            new Item("Soda", 15),
        };
        
        public void ShowList()
        {
            var index = 1;
            foreach (var item in itemsList)
            {
                Console.WriteLine($"{index++}. {item.Name}, {item.Price}kr");
            }
        }
        
        public Item Shop(string input, int money)
        {
            Int32.TryParse(input, out int number);
            
            if (number > 5 || number < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Something went wrong. Please try again.");
                return null;
            }
            
            var selectedItem = itemsList[number - 1];

            if (selectedItem.Price > money)
            {
                Console.WriteLine();
                Console.WriteLine("Woops.. Looks like you don't have enough money. Go to the bank if you want to withdraw some cash."); 
                return null;
            }

            var cost = selectedItem.Price;
            Console.WriteLine();
            Console.WriteLine($"You selected {selectedItem.Name}, enjoy!");
            return selectedItem;
        }
    }
}