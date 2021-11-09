using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    class Rebel : MyDecision
    {
        string name;
        int age;
        string group;
        int food = 0;

        public Rebel(string name, int age, string group)
        {
            this.name = name;
            this.Age = age;
            this.Group = group;

        }

        public int Food { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public override void BuyFood()
        {
            this.food += 5;
        }
        public override int GetFood()
        {
            return this.food;
        }
    }
}
