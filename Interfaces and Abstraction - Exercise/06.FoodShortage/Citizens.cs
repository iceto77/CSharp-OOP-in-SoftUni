using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizens : MyDecision, IIdentity, IBirthday
    {
        private string id;
        private string name;
        private int age;
        private string birthday;
        private int food = 0;

        public Citizens(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public int Food { get; }
        public override void BuyFood()
        {
            this.food += 10;
        }
        public override int GetFood()
        {
            return this.food;
        }
    }
}
