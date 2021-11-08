using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var population = new Dictionary<string, ISociety>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info[0].All(char.IsLetter))
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    if (!population.ContainsKey(id))
                    {
                        population.Add(id, new Citizens(name, age, id));
                    }
                }
                else
                {
                    string model = info[0];
                    string id = info[1];
                    if (!population.ContainsKey(id))
                    {
                        population.Add(id, new Robots(model, id));
                    }
                }
                input = Console.ReadLine();
            }
            string fakeIds = Console.ReadLine();
            foreach (var item in population)
            {
                string current = item.Key.Substring((item.Key.Length) - fakeIds.Length);

                if (current == fakeIds)
                {
                    Console.WriteLine(item.Key);

                }
            }
        }
    }
}
