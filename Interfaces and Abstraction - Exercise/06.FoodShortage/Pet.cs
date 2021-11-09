using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : MyDecision, IBirthday
    {
        private string name;
        private string birthday;



        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        public override void BuyFood()
        {            
        }

        public override int GetFood()
        {
            return 0;
        }
    }
}
