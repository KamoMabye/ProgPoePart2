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
        public double[] QuantOfIn { get; set; }
        public string[] UnitOfIn { get; set; }
        public int NumIn = 0;
        public int NumStep = 0;
        public string[] Steps {get; set; }

        public void createRecipe(string[] ingrName, double[] ingrQuant, string[] ingrUnit )
        {
            int j = 0;
            
            for (int i = 0; i < ingrQuant.Length; i++)
            {
                j++;
                Console.WriteLine($"For ingredient number {j},\n" +
                    $"Please enter the name, quantity and unit of measurement:");
                ingrName[i] = Console.ReadLine();
                try
                {
                    ingrQuant[i] = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please make sure you enter a number!");
                    Environment.Exit(0);
                }

                while (ingrQuant[i] <= 0)
                {
                    Console.WriteLine("Please make sure your quantity is correctly input!");
                    try
                    {
                        ingrQuant[i] = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        Environment.Exit(0);
                    }
                }
                ingrUnit[i] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.WriteLine("Please indicate the amount of steps this recipe requires: ");
            try
            {
               NumStep = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
                Environment.Exit(0);
            }

            QuantOfIn = new double[ingrQuant.Length];
            for (int i = 0;i <ingrQuant.Length;i++)
            {
                QuantOfIn[i] = ingrQuant[i];
            }
            Steps = new string[NumStep];
            int q = 0;
            for (int i = 0; i < Steps.Length; i++)
            {
                q++;
                Console.WriteLine($"Step {q}:");
                Steps[i] = Console.ReadLine();
                Console.WriteLine();
            }
        }
        public void DisplayIngredients(string[] NameOfIn, double[] QuantOfI, string[] UnitOfIn)
        {
            int a = 0;
            Console.WriteLine("List of ingredients:");
            for (int i = 0;i<NameOfIn.Length;i++)// For loop used to loop through the arrays and display the name, quantity and unit of measurement
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + $"Name: {NameOfIn[i]}\n" + $"Quanity: {QuantOfI[i]}\n" + $"Unit of measurement: {UnitOfIn[i]}");
                Console.WriteLine();
            }
            DisplaySteps(Steps);// Will run the display steps method which will display the steps for the recipe
        }
        public void DisplaySteps(string[] Steps)
        {
            int b = 0;
            Console.WriteLine("Steps for the recipe:");
            for (int i = 0; i< Steps.Length;i++)// For loop used to display the array of steps
            {
                b++;
                Console.WriteLine($"Step {b}:\n" +
                    $"{Steps[i]}");
                Console.WriteLine();
            }
        }

        public double[] scaleQuantity(int scale)
        {
            
            
            if (scale == 1)
            {
                for (int i = 0; i < QuantOfIn.Length; i++)//Will scale the quantity of the ingredient depending on which scale is chosen
                {
                    QuantOfIn[i] = QuantOfIn[i] * 0.5;
                }
            }
            else if (scale == 2)
            {
                for (int i = 0; i < QuantOfIn.Length; i++)
                {
                    QuantOfIn[i] = QuantOfIn[i] * 2;
                }
            }
            else
            {
                for (int i = 0; i < QuantOfIn.Length; i++)
                {
                    QuantOfIn[i] = QuantOfIn[i] * 3;
                }
            }

            return QuantOfIn;
        }

        public int Menu(int choice)//This will display a menu wit options for the user
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
                Environment.Exit(0);
            }
            return choice;
        }

        public void resetQuantity(string [] NameOfIn, double[] QuantOfI, string[] UnitOfIn)
        {
            Console.WriteLine("All quantites have been reset to their original quantities.");
           
            int a = 0;
            Console.WriteLine("List of ingredients:");
            for (int i = 0; i < NameOfIn.Length; i++)
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + $"Name: {NameOfIn[i]}\n" + $"Quanity: {QuantOfI[i]}\n" + $"Unit of measurement: {UnitOfIn[i]}");
                Console.WriteLine();
            }
            DisplaySteps(Steps);
        }

        public void deleteRecipe(string[] ingrName, double[] ingrQuant, string[] ingrUnit)
        {
            Array.Clear(ingrName);//These methods will clear out all the arrays
            Array.Clear(ingrQuant);
            Array.Clear(ingrUnit);
            Array.Clear(Steps);
            Console.WriteLine("Your recipe has been deleted! Create a new recipe now:");
        }
    }
}
