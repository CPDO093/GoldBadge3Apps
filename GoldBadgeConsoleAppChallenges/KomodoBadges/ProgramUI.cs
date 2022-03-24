using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class ProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            //Seed();
            Menu();
        }
        private void Menu()
        {
            // main menu with welcome message then
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?");
                Console.WriteLine("1. Add a new Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit Security Module");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreatANewBadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

        }
        // 1. Add badge,
        private void CreatANewBadge()
        {
            Console.Clear();
            List<string> door = new List<string>();

            Console.WriteLine("What is the Badge number: ");
            int badgeNum = int.Parse(Console.ReadLine());
            Console.WriteLine("List door that it needs to access: ");
            door.Add(Console.ReadLine());

            Console.WriteLine("Any other doors? Y/N ");
            switch (Console.ReadLine())
            {
                case "Y":
                case "y":
                case "yes":
                    Console.WriteLine("list door that it needs to access: ");
                    door.Add(Console.ReadLine());
                    break;
                case "N":
                case "n":
                case "no":
                    break;
            };

            _repo.AddBadgeAndAddDoors(badgeNum, door);

            AnyKey();
        }

        // 2. Edit a badge,
        private void EditABadge()
        {
            Console.Clear();

            Console.WriteLine("Admin, enter the Badge number you wish to edit: ");
            int badgeNum = int.Parse(Console.ReadLine());
            _repo.GetBadgeById(badgeNum);

            string door;
            string doorOut;

            Console.WriteLine($"Badge Number {badgeNum} selected.");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("which door would you like to remove? ");
                    doorOut = Console.ReadLine();
                    _repo.RemoveBadgeAcess(badgeNum, doorOut);
                    Console.WriteLine("Door removed.");
                    break;
                case "2":
                    Console.WriteLine("List door that it needs to access: ");
                    door = Console.ReadLine();
                    _repo.UpdateBadgeAccess(badgeNum, door);
                    break;
                default:
                    Console.WriteLine("Please choose 1 or 2. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
            };

            AnyKey();
        }

        // 3. List all badges
        private void ListAllBadges()
        {
            Console.Clear();
            _repo.ListAllBadgesAndAccess();

        }

        private void AnyKey()
        {
            Console.WriteLine("Press anykey to continue...");
            Console.ReadKey();
        }
    }
}
