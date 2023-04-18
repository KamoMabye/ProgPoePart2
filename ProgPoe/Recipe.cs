using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoe
{
    internal class Recipe
    {
        public string[] NameOfIn { get; set; }
        public int[] QuantOfIn { get; set; }
        public string[] UnitOfIn { get; set; }
        public int NumIn = 0;
        public int NumStep = 0;
        public string[] Steps {get; set; }

        public void DisplayIngredients(string[] NameOfIn, int[] QuantOfIn, string[] UnitOfIn)
        {
            int a = 0;
            Console.WriteLine("List of ingredients:");
            for (int i = 0;i<NameOfIn.Length;i++)
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + $"Name: {NameOfIn[i]}\n" + $"Quanity: {QuantOfIn[i]}\n" + $"Unit of measurement: {UnitOfIn[i]}");
                Console.WriteLine();
            }
        }
        public void DisplaySteps(string[] Steps)
        {
            int b = 0;
            Console.WriteLine("Steps for the recipe:");
            for (int i = 0; i< Steps.Length;i++)
            {
                b++;
                Console.WriteLine($"Step {b}:\n" +
                    $"{Steps[i]}");
                Console.WriteLine();
            }
        }
    }
}
