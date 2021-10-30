using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (input != "Beast!")
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];

                switch (input)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine($"{item.GetType().Name}");
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine($"{item.ProduceSound()}");
            }
        }
    }
}
