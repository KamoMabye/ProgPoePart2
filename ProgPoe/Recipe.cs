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

        public void DisplayIngredients(string[] NameOfIn, double[] QuantOfIn, string[] UnitOfIn)
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

        public double[] scaleQuantity(double[] QuantOfIn,int scale)
        {
            double[] scaQuant = new double[QuantOfIn.Length];
            if (scale == 1)
            {
                for (int i = 0; i < scaQuant.Length; i++)
                {
                    scaQuant[i] = QuantOfIn[i] * 0.5;
                }
            }
            else if (scale == 2)
            {
                for (int i = 0; i < scaQuant.Length; i++)
                {
                    scaQuant[i] = QuantOfIn[i] * 2;
                }
            }
            else
            {
                for (int i = 0; i < scaQuant.Length; i++)
                {
                    scaQuant[i] = QuantOfIn[i] * 3;
                }
            }

            return scaQuant;
        }

        public int Menu(int choice)
        {
            Console.WriteLine("What would you like to do with your recipe?\n" +
                "1.) Scale up quantities of ingredients\n" +
                "2.) Reset all ingredient quantites to original\n" +
                "3.) Delete the recipe and create a new one\n" +
                "4.) Exit the application");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
            }
            return choice;
        }
    }
}
