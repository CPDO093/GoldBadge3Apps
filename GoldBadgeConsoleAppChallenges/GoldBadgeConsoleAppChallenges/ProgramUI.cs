using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class ProgramUI
    {
        private readonly MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            Seed();
            Main();
        }
        //main menu with options to see all menu items, add new item, and delete an existing item
        private void Main()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("1. see all menu items\n" +
                    "2. add new menu item\n" +
                    "3. delet menu item\n" +
                    "4. exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListAllMenuItems();
                        break;
                    case "2":
                        AddItemToMenu();
                        break;
                    case "3":
                        RemoveItemFromMenu();
                        break;
                    case "4":
                    case "exit":
                    case "e":
                        runMenu = false;
                        break;
                }
            }
        }

        // call for list
        private void ListAllMenuItems()
        {
            List<Menu> item = _repo.ListAllMenuItems();
            foreach (Menu menu in item)
            {
                Console.WriteLine($"Order number: {menu.MealNumber}\n" +
                    $"Name: {menu.Name}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Ingredients: {menu.Ingredients}\n" +
                    $"Price: {menu.Price}\n");
            }

            AnyKey();
        }
        // call for add
        private void AddItemToMenu()
        {
            Console.Clear();
            Menu menu = new Menu();
            // name
            Console.WriteLine("Enter meal name: ");
            menu.Name = Console.ReadLine();
            //description
            Console.WriteLine("Enter the meal description: ");
            menu.Description = Console.ReadLine();
            //ingredients
            Console.WriteLine("Enter the meals ingredients: ");
            menu.Ingredients = Console.ReadLine();
            //price
            Console.WriteLine("Enter the item price: ");
            menu.Price = double.Parse(Console.ReadLine());
            //meal number
            bool itemNumGood = false;
            while (!itemNumGood)
            {
                Console.WriteLine("Enter item number: ");
                int mealNumber = int.Parse(Console.ReadLine());
                if (_repo.MealNumberAlreadyExist(mealNumber))
                {
                    itemNumGood = true;
                    menu.MealNumber = mealNumber;
                    if (_repo.AddItemToMenu(menu))
                    {
                        Console.WriteLine("Menu item successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Menu item was not added, something went wrong.");
                    }
                }
                else
                {
                    Console.WriteLine("Menu item number already exists, try again.");
                }
                AnyKey();

            }
        }
        // call for delete
        private void RemoveItemFromMenu()
        {
            Console.Clear();
            ListAllMenuItems();
            Console.WriteLine("Enter the number of the menu item you want to remove.");
            Console.WriteLine("Item number: ");
            if (_repo.DeleteMenuItemById(int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Removed successfully.");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            AnyKey();

        }


        private void AnyKey()
        {
            Console.WriteLine("Press anykey to continue");
            Console.ReadKey();
        }
        private void Seed()
        {
            Menu menu = new Menu(1, "Moon Potion", "Energy Drink", "caffine, carbonated water, glucose", 2.50);
            Menu menu2 = new Menu(2, "Bigga Burger", "1/3lb beef patty wrapped in grilled chicken", "grass fed beef, free range chicken, salt, pepper, tomate, pickles, katchup, mustard", 7.25);
            _repo.AddItemToMenu(menu);
            _repo.AddItemToMenu(menu2);
        }
    }
}
