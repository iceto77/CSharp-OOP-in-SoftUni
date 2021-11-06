using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingTypes;
        private Dictionary<string, double> toppingTypesModifier = new Dictionary<string, double>
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };
        private double weight;

        public Topping(string toppingTypes, double weight)
        {
            ToppingTypes = toppingTypes;
            Weight = weight;
        }

        public string ToppingTypes
        {
            get => this.toppingTypes;

            private set
            {
                if (!toppingTypesModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingTypes = value;
            }
        }
        public double Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingTypes} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories
            => 2 * this.Weight * this.toppingTypesModifier[this.toppingTypes.ToLower()];
    }
}
