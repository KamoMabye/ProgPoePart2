namespace ProgPoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            int[] ingr = new int[recipe.NumStep];


            Console.WriteLine("Welcome to the Recipe Creator!\n" +
                "Please indicate how many ingerd");
            recipe.NumStep = Convert.ToInt32(Console.ReadLine());

        }
    }
}