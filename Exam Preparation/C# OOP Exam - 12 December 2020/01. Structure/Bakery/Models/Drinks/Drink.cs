using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;
        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name { get; private set; }

        public int Portion { get; private set; }

        public decimal Price { get; private set; }

        public string Brand { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
        }

    }
}
