using System.Collections;


delegate string totalCalories();
namespace ProgPoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            string recipeName;
            List<double> ingrQuant = new List<double>();
            List<string> ingrName = new List<string>();
            List<string> ingrUnit = new List<string>();
            List<double> ingrCal = new List<double>();
            List<string> ingrFood = new List<string>();
            List<double> totalCalories = new List<double>();
            SortedList<string, string> r = new SortedList<string, string>();

            
            Console.WriteLine("Welcome to the Recipe Creator!\n" +
                "What name will you give this recipe?");
            recipeName = Console.ReadLine();

            Console.WriteLine("Please indicate how many ingredients you would like to have:");
            try
            {
                recipe.NumIn = Convert.ToInt32(Console.ReadLine());//Will allow the user to enter the amount of ingredients they would like to use
            }
            catch (FormatException e)//Added format exception to handle when a user enters characters that are not numbers
            {
                Console.WriteLine("Please make sure you enter a number!");
                Environment.Exit(0);
            }

            Console.WriteLine();
            
            recipe.createRecipe(ingrName,ingrQuant,ingrUnit, ingrCal, ingrFood);// This method will allow the user to create their recipe
            recipe.DisplayIngredients(ingrName,ingrQuant,ingrUnit, ingrCal, ingrFood, totalCalories);// This method will display the ingredients and steps in a nice list
            
            List<double> scaledQuant = new List<double>();
            int choice = 0;
            int c = 0;
            int scale = 0;
            c = recipe.Menu(choice);// Displays a menu which allows the user to scale up ingredients, reset the quantites and delete their recipe
            while (!(c >=4))
            {
                if (c == 1)//Will allow the user to scale up their ingredient quantity
                {
                    
                    Console.WriteLine("Please indicate how much you would like to scale the quantities by:\n" +
                        "1.) Scale by 0.5\n" +
                        "2.) Scale by 2\n" +
                        "3.) Scale by 3");
                    try
                    {
                        scale = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        Environment.Exit(0);
                    }
                    
                    scaledQuant = recipe.scaleQuantity(scale);// This method scales up the quantites

                    if (scale == 1)
                    {
                        Console.WriteLine("Your ingredient quantities were  scaled by 0.5");
                    }
                    else if (scale == 2)
                    {
                        Console.WriteLine("Your ingredient quantities were  scaled by 2");
                    }
                    else
                    {
                        Console.WriteLine("Your ingredient quantities were scaled by 3");
                    }

                    Console.WriteLine("Here is the result:");
                    recipe.DisplayIngredients(ingrName, scaledQuant, ingrUnit, ingrCal, ingrFood, totalCalories);//This will display the scaled up ingredients

                    

                    c = recipe.Menu(choice);
                }
                else if (c == 2)
                {
                    int con = 0;
                    Console.WriteLine("You chose to reset all your quantites. Do you want to continue?\n" +
                        "1.) Yes\n" +
                        "2.) No");
                    try
                    {
                        con = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        Environment.Exit(0);
                    }

                    if (con == 1)
                    {
                        for (int i = 0; i < ingrQuant.Count; i++)
                        {
                            scaledQuant[i] = ingrQuant[i];
                        }
                        recipe.resetQuantity(ingrName,ingrQuant, ingrUnit);// This method resets the quantities to the original value
                        
                    }
                    else
                    {
                        Console.WriteLine("Your quantities have not been reset!");
                    }

                    c = recipe.Menu(choice);
                }
                else if (c == 3)
                {
                    int d = 0;
                    Console.WriteLine("You are going to delete your recipe. Do you want to continue?\n" +
                        "1.) Yes\n" +
                        "2.) No");
                    try
                    {
                        d = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        Environment.Exit(0);
                    }

                    if (d == 1)
                    {
                        recipe.deleteRecipe(ingrName, ingrQuant, ingrUnit);//Will clear all arrays 
                        Console.WriteLine("Please indicate how many ingredients you would like to have:");
                        try
                        {
                            recipe.NumIn = Convert.ToInt32(Console.ReadLine());//Will allow the user to enter the amount of ingredients they would like to use
                        }
                        catch (FormatException e)//Added format exception to handle when a user enters characters that are not numbers
                        {
                            Console.WriteLine("Please make sure you enter a number!");
                            Environment.Exit(0);
                        }
                        recipe.createRecipe(ingrName, ingrQuant, ingrUnit, ingrCal, ingrFood);// This method will allow the user to create their recipe
                        recipe.DisplayIngredients(ingrName, ingrQuant, ingrUnit, ingrCal, ingrFood, totalCalories);// This method will display the ingredients and steps in a nice list

                    }
                    else
                    {
                        Console.WriteLine("Your recipe was not deleted.");
                    }
                    c = recipe.Menu(choice);
                }

            }
            Console.WriteLine("Thank you for using the Recipe Creator!");//Once the user choses to exit the application, it will display a thank you message.
            Console.ReadKey();
        }
    }
}