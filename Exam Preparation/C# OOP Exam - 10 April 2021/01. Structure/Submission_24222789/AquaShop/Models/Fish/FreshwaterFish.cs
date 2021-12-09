using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {   //Can only live in FreshwaterAquarium!
        private int size;  
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.size = 3;
        }
        public int Size { get; private set; }
        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
