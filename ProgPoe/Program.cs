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

            int[] ingrQuant = new int[recipe.NumIn];
            string[] ingrName = new string[recipe.NumIn];
            string[] ingrUnit = new string[recipe.NumIn];

            

            int j = 0;
            for (int i = 0; i<ingrQuant.Length; i++)
            {
                j++;
                Console.WriteLine($"For ingredient number {j},\n" +
                    $" Please enter the name, quantity and unit of measurment:");
                ingrName[i] = Console.ReadLine();
                try
                {
                    ingrQuant[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please make sure you enter a number!");
                }

                while (ingrQuant[i] <= 0)
                {
                    Console.WriteLine("Please make sure your quantity is correctly input!");
                    ingrQuant[i] = Convert.ToInt32(Console.ReadLine());
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

        }
    }
}