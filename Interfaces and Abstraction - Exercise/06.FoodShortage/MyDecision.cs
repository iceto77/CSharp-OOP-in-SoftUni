
using System;

namespace FoodShortage
{
    public abstract class MyDecision : IName, IBirthday, IIdentity, IBuyer
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public string Birthday { get; set; }

        public int Food => throw new NotImplementedException();

        public abstract void BuyFood();

        public abstract int GetFood();
    }
}
