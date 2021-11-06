using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> flourTypeCaloriesModifier = new Dictionary<string, double>
        {
            { "white", 1.5},
            { "wholegrain", 1.0}
        };
        private Dictionary<string, double> bakingTechniqueCaloriesModifier = new Dictionary<string, double>
        {
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0}
        };
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!flourTypeCaloriesModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (!bakingTechniqueCaloriesModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Calories
            => 2 * this.Weight * this.flourTypeCaloriesModifier[this.FlourType.ToLower()] * this.bakingTechniqueCaloriesModifier[this.BakingTechnique.ToLower()];

    }
}
