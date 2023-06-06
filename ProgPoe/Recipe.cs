using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoe
{
    internal class Recipe
    {

        public delegate string calExceeds(double calories);
        public string recipeName { get; set; }
        public List<Ingredient> ingredient = new List<Ingredient>();
        public List<string> Steps = new List<string>();

        public void createRecipe(List<string> ingrName, List<double> ingrQuant, List<string> ingrUnit, List<double> ingrCal, List<string> ingrFood)
        {
            int j = 0;
            
            for (int i = 0; i < NumIn; i++)
            {
                j++;
                Console.WriteLine($"For ingredient number {j},\n" +
                    $"Please enter the name, quantity and unit of measurement:");
                ingrName.Add(Console.ReadLine());

                try
                {
                    ingrQuant.Add(Convert.ToDouble(Console.ReadLine()));
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
                        ingrQuant.Add(Convert.ToDouble(Console.ReadLine()));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        Environment.Exit(0);
                    }
                }
                ingrUnit.Add(Console.ReadLine());
                Console.WriteLine("Please enter the amount of calories for this ingredient:");
                ingrCal.Add(Convert.ToDouble(Console.ReadLine()));
                Console.WriteLine("Please specify the food group of the ingredient by inputting a number:\n" +
                    "1. Starchy Food\n" +
                    "2. Fruits and Vegetables\n" +
                    "3. Dry beans, peas, lentils and soya\n" +
                    "4. Chicken, fish, meat and eggs\n" +
                    "5. Milk and dairy products\n" +
                    "6. Fats and oils" +
                    "7. Water");
                int foodGrp = 0;
                foodGrp = Convert.ToInt32(Console.ReadLine());
                
                while (foodGrp <= 0 || foodGrp > 7)
                {
                    Console.WriteLine("Please make sure you select the correct number for the food group!");
                    Console.WriteLine("Please specify the food group of the ingredient by inputting a number:\n" +
                    "1. Starchy Food\n" +
                    "2. Fruits and Vegetables\n" +
                    "3. Dry beans, peas, lentils and soya\n" +
                    "4. Chicken, fish, meat and eggs\n" +
                    "5. Milk and dairy products\n" +
                    "6. Fats and oils" 
                    "7. Water");
                    foodGrp = Convert.ToInt32(Console.ReadLine());
                }

                switch (foodGrp)
                {
                    case 1:
                        ingrFood.Add("Starchy Food");
                        break;
                    case 2:
                        ingrFood.Add("Fruits and Vegetables");
                        break;
                    case 3:
                        ingrFood.Add("Dry beans, peas, lentils and soya");
                        break;
                    case 4:
                        ingrFood.Add("Chicken, fish, meat and eggs");
                        break;
                    case 5:
                        ingrFood.Add("Milk and dairy products");
                        break;
                    case 6:
                        ingrFood.Add("Fats and oils");
                        break;
                    case 7:
                        ingrFood.Add("Water");
                        break;
                }



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

                QuantOfIn.AddRange(ingrQuant);


            int q = 0;
            for (int i = 0; i < NumStep; i++)
            {
                q++;
                Console.WriteLine($"Step {q}:");
                Steps.Add(Console.ReadLine());
                Console.WriteLine();
            }
        }
        public void DisplayIngredients(List<string> NameOfIn, List<double> QuantOfI, List<string> UnitOfIn, List<double> ingrCal, List<string> ingrFood, List<double> totalCalories)
        {
            int a = 0;
            Console.WriteLine("List of ingredients:");
            for(int i = 0;i<NumIn;i++)// For loop used to loop through the arrays and display the name, quantity and unit of measurement
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + 
                    $"Name: {NameOfIn[i]}\n" + 
                    $"Quanity: {QuantOfI[i]}\n" + 
                    $"Unit of measurement: {UnitOfIn[i]}\n" +
                    $"Calories: {ingrCal[i]}\n" +
                    $"Food Group: {ingrFood[i]}");
                Console.WriteLine();
            }
            double total =  0;
            total = calCalculation(ingrCal);
            totalCalories.Add(total);
            Console.WriteLine($"Total amount of calories for this recipe is: {total}");
            calExceeds c = new calExceeds(totalCal);
            Console.WriteLine(c(total));
            
            DisplaySteps(Steps);// Will run the display steps method which will display the steps for the recipe
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

        public List<double> scaleQuantity(int scale)
        {
            
            
            if (scale == 1)
            {
                for (int i = 0; i < QuantOfIn.Count; i++)//Will scale the quantity of the ingredient depending on which scale is chosen
                {
                    QuantOfIn[i] = QuantOfIn[i] * 0.5;
                }
            }
            else if (scale == 2)
            {
                for (int i = 0; i < QuantOfIn.Count; i++)
                {
                    QuantOfIn[i] = QuantOfIn[i] * 2;
                }
            }
            else
            {
                for (int i = 0; i < QuantOfIn.Count; i++)
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

        public void resetQuantity(List<string> NameOfIn, List<double> QuantOfI, List<string> UnitOfIn)
        {
            Console.WriteLine("All quantites have been reset to their original quantities.");
           
            int a = 0;
            Console.WriteLine("List of ingredients:");
            for (int i = 0; i < NumIn; i++)
            {
                a++;
                Console.WriteLine($"Ingredient {a}:\n" + 
                    $"Name: {NameOfIn[i]}\n" + 
                    $"Quanity: {QuantOfI[i]}\n" + 
                    $"Unit of measurement: {UnitOfIn[i]}");
                Console.WriteLine();
            }
            DisplaySteps(Steps);
        }

        public void deleteRecipe(List<string> ingrName, List<double> ingrQuant, List<string> ingrUnit)
        {
            ingrName.Clear();//These methods will clear out all the arrays
            ingrQuant.Clear();
            ingrUnit.Clear();
            Steps.Clear();
            Console.WriteLine("Your recipe has been deleted! Create a new recipe now:");
        }

        public string totalCal(double calories)
        {
            if(calories > 300){
                return "Your total calories for this recipe exceed 300!";
            }
            else
            {
                return " ";
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
