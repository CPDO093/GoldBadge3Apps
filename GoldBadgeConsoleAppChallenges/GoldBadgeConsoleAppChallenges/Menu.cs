using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class Menu
    {
        // all menu items will have these attributes
        // a meal number
        public int MealNumber { get; set; }
        //a meal name
        public string Name { get; set; }
        // a description
        public string Description { get; set; }
        //a list of igredients
        public string Ingredients { get; set; }
        //a price
        public double Price { get; set; }

        public Menu() { }
        public Menu(int mealNumber)
        {

            MealNumber = mealNumber;
        }
        public Menu(int mealNumber, string name) : this(mealNumber)
        {
            Name = name;

        }
        public Menu(int mealNumber, string name, string description) : this(mealNumber, name)
        {
            Description = description;

        }
        public Menu(int mealNumber, string name, string description, string ingredients) : this(mealNumber, name, description)
        {
            Ingredients = ingredients;

        }
        public Menu(int mealNumber, string name, string description, string ingredients, double price) : this(mealNumber, name, description, ingredients)
        {
            Price = price;

        }
    }
}
