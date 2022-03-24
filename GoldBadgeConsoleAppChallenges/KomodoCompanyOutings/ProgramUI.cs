using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings
{
    public class ProgramUI
    {
        private readonly CompanyOutingRepo _repo = new CompanyOutingRepo();
        public void Run()
        {
            //seed();
            Menu();
        }

        // menu with welcome message
        private void Menu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Wellcom Admin, What would you like to do?");
                Console.WriteLine("1. See list of all outings\n" +
                    "2. Add a new company outing\n" +
                    "3. Display outing costs\n" +
                    "4. Exit Console");
                switch (Console.ReadLine())
                {
                    case "1":
                        SeeAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        CostsMenu();
                        break;
                    case "e":
                    case "4":
                    case "exit":
                        runMenu = false;
                        break;
                    defualt:
                        Console.WriteLine("please enter a number between 1 and 3.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // 1. list of all outings,
        private void SeeAllOutings()
        {
            Clear();
            DisplayAllEvents();
            AnyKey();


        }
        // 2. add and outing,
        private void AddNewOuting()
        {
            Clear();
            CompanyOuting outing = new CompanyOuting();
            Console.WriteLine("What is the new outings event type?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusment Park\n" +
                "4. Concert");
            string type = Console.ReadLine();

            switch (type)
            {
                case "1":
                case "golf":
                    outing.EventType = EventType.Golf;
                    break;
                case "2":
                case "bowling":
                    outing.EventType = EventType.Bowling;
                    break;
                case "3":
                case "amusment park":
                    outing.EventType = EventType.AmusmentPark;
                    break;
                case "4":
                case "concert":
                    outing.EventType = EventType.Concert;
                    break;
            }
            Console.WriteLine("How many people will be attending the event: ");
            outing.PeopleAttending = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cost per person: ");
            outing.IndivCost = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the scheduled date of the outing: ");
            outing.Date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the total event cost: ");
            outing.EventCost = double.Parse(Console.ReadLine());

            if (_repo.AddNewCompOuting(outing))
            {
                Console.WriteLine("New company event added successfully!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Failure to add new event!");
                AnyKey();
            }

        }
        // 3. calculations
        private void CostsMenu()
        {
            Clear();
            Console.WriteLine("Admin, what would you like to see?");
            Console.WriteLine("1. Total combined cost of all scheduled outings\n" +
                "2. Total combined cost of outings by type/n" +
                "3. Exit cost menu");
            switch (Console.ReadLine())
            {
                case "1":
                    TotalCombinedCost();
                    break;
                case "2":
                    CombinedCostByType();
                    break;
                case "3":
                case "e":
                case "exit":
                    Menu();
                    break;
                defualt:
                    Console.WriteLine("Please choose and option, either 1 or 2");
                    break;
            }
        }
        // 3. => 1. combined cost for all outings, 2. combind cost by type of outing
        private void TotalCombinedCost()
        {
            Clear();
            _repo.GetTotalCombinedCost();
            AnyKey();

        }
        private void CombinedCostByType()
        {
            Clear();

            Console.WriteLine("Please Choose Type of Event by number:\n" +
                "1. Golf Events\n" +
                "2. Bowling Events\n" +
                "3. Amusment Park Events\n" +
                "4. Concert Events\n");
            EventType type;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Combined cost of all Golf Events: ");
                    _repo.GetOutingCostByType(EventType.Golf);
                    break;
                case "2":
                    Console.WriteLine("Combined cost of all Bowling Events: ");
                    _repo.GetOutingCostByType(EventType.Bowling);
                    break;
                case "3":
                    Console.WriteLine("Combined cost of all Amusment Park Events: ");
                    _repo.GetOutingCostByType(EventType.AmusmentPark);
                    break;
                case "4":
                    Console.WriteLine("Combined cost of all Concert Events: ");
                    _repo.GetOutingCostByType(EventType.Concert);
                    break;
            }
            AnyKey();
        }

        private void DisplayAllEvents()
        {
            List<CompanyOuting> outings = _repo.GetAllOutings();
            foreach (CompanyOuting outing in outings)
            {
                Console.WriteLine($"Company outing type: {outing.EventType}\n" +
                    $"People Attending: {outing.PeopleAttending}\n" +
                    $"Event Date: {outing.Date}\n" +
                    $"Cost Per Person: {outing.IndivCost}\n" +
                    $"Event Cost: {outing.EventCost}");
            }

        }
        private void AnyKey()
        {
            Console.WriteLine("press anykey to conitnue");
            Console.ReadKey();
        }
        private void Clear()
        {
            Console.Clear();
        }
    }
}
