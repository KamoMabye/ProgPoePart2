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
            for (int i = 0;i<NameOfIn.Length;i++)
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + $"Name: {NameOfIn[i]}\n" + $"Quanity: {QuantOfIn[i]}\n" + $"Unit of measurment: {UnitOfIn[i]}");
                Console.WriteLine();
            }
        }
    }
}
