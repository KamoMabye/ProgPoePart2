namespace ProgPoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Welcome to the Recipe Creator!\n" +
                "Please indicate how many ingredients you would like to have:");
            try
            {
                recipe.NumIn = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
            }

            Console.WriteLine();

            double[] ingrQuant = new double[recipe.NumIn];
            string[] ingrName = new string[recipe.NumIn];
            string[] ingrUnit = new string[recipe.NumIn];

            

            int j = 0;
            for (int i = 0; i<ingrQuant.Length; i++)
            {
                j++;
                Console.WriteLine($"For ingredient number {j},\n" +
                    $" Please enter the name, quantity and unit of measurement:");
                ingrName[i] = Console.ReadLine();
                try
                {
                    ingrQuant[i] = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please make sure you enter a number!");
                }

                while (ingrQuant[i] <= 0)
                {
                    Console.WriteLine("Please make sure your quantity is correctly input!");
                    ingrQuant[i] = Convert.ToDouble(Console.ReadLine());
                }
                ingrUnit[i] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.WriteLine("Please indicate the amount of steps this recipe requires: ");
            try
            {
                recipe.NumStep = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please make sure you enter a number!");
            }

            string[] steps = new string[recipe.NumStep];
            int q = 0;
            for (int i = 0; i < steps.Length;i++)
            {
                q++;
                Console.WriteLine($"Step {q}:");
                steps[i] = Console.ReadLine();
                Console.WriteLine();
            }
            recipe.DisplayIngredients(ingrName,ingrQuant,ingrUnit);
            recipe.DisplaySteps(steps);
            int choice = 0;
            int c = 0;
            c = recipe.Menu(choice);
            while (!(c >=4))
            {
                if (c == 1)
                {
                    double[] scaledQuant = new double[ingrQuant.Length];
                    int scale = 0;
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
                    }

                    scaledQuant = recipe.scaleQuantity(ingrQuant, scale);

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
                    recipe.DisplayIngredients(ingrName, scaledQuant, ingrUnit);
                    recipe.DisplaySteps(steps);

                    recipe.Menu(choice);
                }
            }
               
            
        }
    }
}