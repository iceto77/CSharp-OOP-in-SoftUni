using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                string[] dataInfo = input.Split();
                string pizzaName = dataInfo[1];
                input = Console.ReadLine();
                dataInfo = input.Split();
                Dough dough = new Dough(dataInfo[1], dataInfo[2], int.Parse(dataInfo[3]));
                Pizza pizzes = new Pizza(pizzaName, dough);
                input = Console.ReadLine();
                while (input != "END")
                {
                    dataInfo = input.Split();
                    pizzes.AddTopping(new Topping(dataInfo[1], double.Parse(dataInfo[2])));
                    input = Console.ReadLine();
                }
                string test1 = pizzes.Name;
                double test3 = dough.Calories;
                double test2 = pizzes.Calories(dough.Calories);
                Console.WriteLine($"{pizzes.Name} - {pizzes.Calories(dough.Calories):f2} Calories.");
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
    }
}
