using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<MyDecision> myList = new List<MyDecision>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (info[0])
                {
                    case "Citizen":
                        string name = info[1];
                        int age = int.Parse(info[2]);
                        string id = info[3];
                        string birthday = info[4];
                        myList.Add(new Citizens(name, age, id, birthday));
                        break;
                    case "Pet":
                        name = info[1];
                        birthday = info[2];
                        myList.Add(new Pet(name, birthday));
                        break;
                    case "Robot":
                        string model = info[1];
                        id = info[2];
                        myList.Add(new Robots(model, id));
                        break;
                }
                input = Console.ReadLine();
            }
            int targetYear = int.Parse(Console.ReadLine());
            foreach (var item in myList)
            {
                int year = item.GetBirthdayYear();
                if (year == targetYear)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }
        }
    }
}
