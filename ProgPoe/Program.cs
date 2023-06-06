using System.Collections;
using System.Net.NetworkInformation;


delegate string totalCalories();
namespace ProgPoe
{
    internal class Program
    {
        static List<Recipe> recipes = new List<Recipe>();
        static void Main(string[] args)
        {
            
            
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

            while (choice <=4)
            {

                Console.WriteLine("Welcome to the Recipe Creator!\n" +
                            "1.) Create new recipe\n" +
                            "2.) Show created recipes\n" +
                            "3.) Select a recipe\n" +
                            "4.) Exit");

                if (choice == 1)
                {
                    createRecipe();
                }
            }

             
            

            
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

        static void createRecipe()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Please enter the name of the recipe:");
            recipe.recipeName = Console.ReadLine();

            Console.WriteLine("Please indicate how many ingredients you would like to have:");
            int numIn = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numIn;i++)
            {
                Ingredient ingr = new Ingredient();

                Console.WriteLine($"For ingredient number {j},\n" +
                $"Please enter the name, quantity and unit of measurement:");

                ingr.ingrName = Console.ReadLine();
                ingr.ingrQuant = Convert.ToDouble(Console.ReadLine());
                ingr.ingrUnit = Console.ReadLine();

                Console.WriteLine("Please enter the amount of calories for this ingredient:");
                ingr.ingrCal = Convert.ToDouble(Console.ReadLine());
                int foodGrp = 0;
                while (foodGrp <= 0 || foodGrp > 7)
                {
                    Console.WriteLine("Please make sure you select the correct number for the food group!");
                    Console.WriteLine("Please specify the food group of the ingredient by inputting a number:\n" +
                    "1. Starchy Food\n" +
                    "2. Fruits and Vegetables\n" +
                    "3. Dry beans, peas, lentils and soya\n" +
                    "4. Chicken, fish, meat and eggs\n" +
                    "5. Milk and dairy products\n" +
                    "6. Fats and oils" +
                    "7. Water");
                    foodGrp = Convert.ToInt32(Console.ReadLine());
                }

                switch (foodGrp)
                {
                    case 1:
                        ingr.ingrFood = "Starchy Food";
                        break;
                    case 2:
                        ingr.ingrFood = "Fruits and Vegetables";
                        break;
                    case 3:
                        ingr.ingrFood = "Dry beans, peas, lentils and soya";
                        break;
                    case 4:
                        ingr.ingrFood = "Chicken, fish, meat and eggs";
                        break;
                    case 5:
                        ingr.ingrFood = "Milk and dairy products";
                        break;
                    case 6:
                        ingr.ingrFood = "Fats and oils";
                        break;
                    case 7:
                        ingr.ingrFood = "Water";
                        break;
                }

                recipe.ingredient.Add(ingr);
            }

            Console.WriteLine("Please indicate the amount of steps this recipe requires: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i< numSteps;i++)
            {
                string step = Console.ReadLine();
                recipe.Steps.Add(step);
            }
            recipes.Add(recipe);

            Console.WriteLine("Recipe added successfully!");
        }

    }
}