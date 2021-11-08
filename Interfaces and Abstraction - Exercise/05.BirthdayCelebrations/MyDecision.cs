
using System;

namespace BirthdayCelebrations
{
    public abstract class MyDecision : IName, IBirthday, IIdentity
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public string Birthday { get; set; }
        public abstract int GetBirthdayYear();
    }
}
