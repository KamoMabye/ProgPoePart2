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

            recipe.createRecipe(ingrName,ingrQuant,ingrUnit);
            recipe.DisplayIngredients(ingrName,ingrQuant,ingrUnit);

            double[] scaledQuant = new double[ingrQuant.Length];
            int choice = 0;
            int c = 0;
            int scale = 0;
            c = recipe.Menu(choice);
            while (!(c >=4))
            {
                if (c == 1)
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
                    }
                    double[] scaQuant = new double[ingrQuant.Length];
                    for (int i = 0; i < ingrQuant.Length;i++)
                    {
                        scaQuant[i] = ingrQuant[i];
                    }
                    scaledQuant = recipe.scaleQuantity(scaQuant, scale);

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
                    }

                    if (con == 1)
                    {
                        for (int i = 0; i < ingrQuant.Length; i++)
                        {
                            scaledQuant[i] = ingrQuant[i];
                        }
                        recipe.resetQuantity(ingrName,ingrQuant, ingrUnit);
                        
                    }
                    else
                    {
                        Console.WriteLine("Your quantities have not been reset!");
                    }

                    c = recipe.Menu(choice);
                }

            }
               
            
        }
    }
}