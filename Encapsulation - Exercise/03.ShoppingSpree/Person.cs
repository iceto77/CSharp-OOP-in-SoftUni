using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts => this.bagOfProducts;

        public void AddProduct(Product item)
        {
            this.money -= item.Cost;
            bagOfProducts.Add(item);
        }
        public string PrintBagOfProducts()
        {
            if (bagOfProducts.Count > 0)
            {
                List<string> productsName = new List<string>();
                foreach (var item in bagOfProducts)
                {
                    productsName.Add(item.Name);
                }
                return String.Join(", ", productsName);
            }
            return $"Nothing bought";
        }
    }
}
