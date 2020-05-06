using System;
using System.Collections.Generic;

namespace awesomeProject
{
    public class User
    {
        public string Name { get; }
        public int Cash { get; private set; }
        
        public List<Item> itemsInBag;
        
        public User(string name)
        {
            Name = name;
            itemsInBag = new List<Item>();
        }

        public void GetCash(int amount)
        {
            Cash += amount;
        }

        public void RemoveCash(int amount)
        {
            Cash -= amount;
        }
        
        public void AddItemToBag(Item item)
        {
            if (item == null)
            {
                return;
            }
            
            itemsInBag.Add(item);
        }

        public void CheckBag()
        {
            if (itemsInBag.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Your bag is empty. Go buy something!");
                return;
            }

            Console.WriteLine();
            foreach (var item in itemsInBag)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }
}