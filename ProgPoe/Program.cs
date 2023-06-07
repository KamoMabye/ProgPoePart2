using ProgPoe;
using System.Collections;
using System.Net.NetworkInformation;
using static System.Formats.Asn1.AsnWriter;


namespace ProgPoe
{
    
    internal class Program
    {
        static List<Recipe> recipes = new List<Recipe>();
        

        static void Main(string[] args)
        {
            
            int choice = 0;
            
            while (choice <4)
            {

                Console.WriteLine("Welcome to the Recipe Creator!\n" +
                            "1.) Create new recipe\n" +
                            "2.) Show created recipes\n" +
                            "3.) Select a recipe\n" +
                            "4.) Exit");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please make sure you enter a number!");
                    return;
                }

                if (choice == 1)
                {
                    createRecipe();
                }
                else if (choice == 2)
                {
                    showRecipes();
                }
                else if (choice == 3)
                {
                    selectRecipe();
                }
            }

            Console.WriteLine("Thank you for using the Recipe Creator!");//Once the user choses to exit the application, it will display a thank you message.
            Console.ReadKey();
        }

        static void createRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.calExceeds += calExceededMessage;

            Console.WriteLine("Please enter the name of the recipe:");
            recipe.recipeName = Console.ReadLine();

            Console.WriteLine("Please indicate how many ingredients you would like to have:");
            int numIn = 0;
            try
            {
                numIn = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
                return;
            }

            for (int i = 0; i < numIn;i++)
            {
                Ingredient ingr = new Ingredient();

                Console.WriteLine($"For ingredient number {i + 1},\n" +
                $"Please enter the name, quantity and unit of measurement:");

                ingr.ingrName = Console.ReadLine();
                try
                {
                    ingr.ingrQuant = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please make sure you enter a number!");
                    return;
                }
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
                    "6. Fats and oils\n" +
                    "7. Water");
                    try
                    {
                        foodGrp = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please make sure you enter a number!");
                        return;
                    }
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
            int numSteps = 0;
            try
            {
                numSteps = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
                return;
            }
            

            for (int i = 0; i< numSteps;i++)
            {
                Console.Write($"Step {i + 1}:");
                string step = Console.ReadLine();
                recipe.Steps.Add(step);
            }
            recipes.Add(recipe);

            Console.WriteLine("Recipe added successfully!");
        }

        static void showRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("All Recipes:");

            foreach (Recipe recipe in recipes.OrderBy(r => r.recipeName))
            {
                Console.WriteLine($"{recipe.recipeName}");
            }
        }

        static void selectRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select a recipe: ");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}.) {recipes[i].recipeName}");
            }

            Console.WriteLine("Indicate which recipe you would like to see: ");
            int recipeNum = 0;
            try
            {
                recipeNum = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
                return;
            }
            

            if (recipeNum <= 0 || recipeNum > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number. Please try again.");
                return;
            }

            Recipe selectedRecipe = recipes[recipeNum - 1];
            Console.WriteLine($"Recipe Name: {selectedRecipe.recipeName}");

            foreach (Ingredient i in selectedRecipe.ingredient)// For loop used to loop through the arrays and display the name, quantity and unit of measurement
            {
                Console.WriteLine(
                    $"Name: {i.ingrName}\n" +
                    $"Quanity: {i.ingrQuant}\n" +
                    $"Unit of measurement: {i.ingrUnit}\n" +
                    $"Calories: {i.ingrCal}\n" +
                    $"Food Group: {i.ingrFood}");
                Console.WriteLine();
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < selectedRecipe.Steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {selectedRecipe.Steps[i]} ");
            }

            double totalCalories = selectedRecipe.totalCalories();
            Console.WriteLine($"Total Calories for this recipe: {totalCalories}");
            

            Console.WriteLine("What would you like to do to this recipe?\n" +
                   "1.) Scale the quantites by 0.5\n" +
                   "2.) Scale the quantites by 2\n" +
                   "3.) Scale the quantites by 3\n" +
                   "4.) Reset all quantites to original\n" +
                   "5.) Return to main menu");
            int choice2 = 0;
            try
            {
                choice2 = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
                return;
            }
            

            if (choice2 == 1)
            {
                scaleQuantities(selectedRecipe, 0.5);
            }
            else if (choice2 == 2)
            {
                scaleQuantities(selectedRecipe, 2);
            }
            else if (choice2 == 3)
            {
                scaleQuantities(selectedRecipe, 3);
            }
            else if (choice2 == 4)
            {
                resetQuantites(selectedRecipe);
            }
            else
            {
                return;
            }
        }

        static void scaleQuantities(Recipe recipe, double scale)
        {
            foreach (Ingredient ingr in recipe.ingredient)
            {
                ingr.ingrQuant = ingr.ingrQuant * scale;
            }

            Console.WriteLine($"The quantities have been scaled by {scale}");
        }

        static void resetQuantites(Recipe recipe)
        {
            foreach (Ingredient ingr in recipe.ingredient)
            {
                ingr.ingrQuant = ingr.ingrQuant;
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        static void calExceededMessage(Recipe recipe)
        {
            Console.WriteLine($"The recipe {recipe.recipeName} exceeds 300 calories!");
        }
    }
}
