using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;
        public BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name { get; private set; }
              
        public int Portion { get; private set; }
              
        public decimal Price { get; private set; }
        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price}";
        }
    }
}
