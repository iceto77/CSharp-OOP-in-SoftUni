using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robots : MyDecision, IIdentity
    {
        private string name;
        private string id;

        public Robots(string model, string id)
        {
            this.Name = model;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }

        public override int GetBirthdayYear()
        {
            return 0;
        }
    }
}
