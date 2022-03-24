using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuRepo
    {
        // a method for adding menu items
        // a method for seeing all items (list to list)
        // a method for deleting items (by meal number)
        protected readonly List<Menu> _menu = new List<Menu>();
        public bool AddItemToMenu(Menu menu)
        {
            int startingCount = _menu.Count();
            _menu.Add(menu);
            bool wasAdded = (_menu.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        public bool MealNumberAlreadyExist(int mealNumber)
        {
            foreach (var mealNumberExisits in _menu)
            {
                if (mealNumberExisits.MealNumber == mealNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public Menu GetMenuByNumber(int menuNumber)
        {
            return _menu.Where(n => n.MealNumber == menuNumber).SingleOrDefault();
        }
        public List<Menu> ListAllMenuItems()
        {
            return _menu;
        }
        public bool DeleteMenuItem(Menu menuItem)
        {
            bool result = _menu.Remove(menuItem);
            return result;
        }
        public bool DeleteMenuItemById(int menuNumber)
        {
            var menu = GetMenuByNumber(menuNumber);
            if (menu != null)
            {
                bool deleteItem = _menu.Remove(menu);
                return deleteItem;
            }
            else
            {
                return false;
            }
        }
    }
}
