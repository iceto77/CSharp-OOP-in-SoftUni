using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var persons = new Dictionary<string, Person>();
                string[] inputLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var person in inputLine)
                {
                    string[] personInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    persons.Add(personInfo[0], new Person(personInfo[0], int.Parse(personInfo[1])));

                }
                var products = new Dictionary<string, Product>();
                inputLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var product in inputLine)
                {
                    string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    products.Add(productInfo[0], new Product(productInfo[0], int.Parse(productInfo[1])));
                }
                string input = Console.ReadLine();
                while (input != "END")
                {
                    inputLine = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person currentPerson = persons[inputLine[0]];
                    Product currentProduct = products[inputLine[1]];
                    if (currentPerson.Money >= currentProduct.Cost)
                    {
                        persons[inputLine[0]].AddProduct(currentProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }
                    input = Console.ReadLine();
                }
                foreach (var people in persons)
                {
                    Console.WriteLine($"{people.Key} - {people.Value.PrintBagOfProducts()}");
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }

    }
}
