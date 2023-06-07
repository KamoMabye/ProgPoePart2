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

            foreach (Ingredient ingr in ingredient)
            {
                totalCalories = totalCalories + ingr.ingrCal;
            }

            if (totalCalories > 300)
            {
                calExceeds?.Invoke(this);
            }

            return totalCalories;
        }

        
        public void DisplaySteps(List<string> Steps)
        {
            int b = 0;
            Console.WriteLine("Steps for the recipe:");
            foreach (var s in Steps)
            {
                b++;
                Console.WriteLine($"Step {b}:" +
                    $"{s}");
                
            }
        }


        public double calCalculation(List<double> ingrCal)
        {
            double t = 0;
            for (int i = 0; i< ingrCal.Count; i++)
            {
                t = ingrCal[i] + t;
            }

            return t;
        }
    }
}
