using System;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, MyDecision> myList = new Dictionary<string, MyDecision>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthday = info[3];
                    myList.Add(name, new Citizens(name, age, id, birthday));
                }
                else if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];
                    myList.Add(name, new Rebel(name, age, group));
                }
            }
            string person = Console.ReadLine();
            while (person != "End")
            {
                if (myList.ContainsKey(person))
                {
                    myList[person].BuyFood();
                }   
                person = Console.ReadLine();
            }
            int sum = 0;
            foreach (var item in myList)
            {
                sum += item.Value.GetFood();
            }
            Console.WriteLine(sum);
        }
    }
}
