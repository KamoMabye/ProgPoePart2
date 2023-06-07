using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoe
{
    internal class Recipe
    {
        public delegate void RecipeNotification(Recipe recipe);
        public string recipeName { get; set; }
        public List<Ingredient> ingredient = new List<Ingredient>();
        public List<string> Steps = new List<string>();
        public event RecipeNotification calExceeds;

        public double totalCalories()
        {
            double totalCalories = 0;

            foreach (Ingredient ingr in ingredient)// Will add up all calories into a total
            {
                totalCalories = totalCalories + ingr.ingrCal;
            }

            if (totalCalories > 300)// This checks if the total calories is over 300 and will envoke a method which will display an appropriate message
            {
                calExceeds?.Invoke(this);
            }

            return totalCalories;
        }

        
    }
}
