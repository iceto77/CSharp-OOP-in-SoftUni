using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
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

        public override int GetBirthdayYear()
        {
            string[] date = this.Birthday.Split('/');
            int year = int.Parse(date[2]);
            return year;
        }
        public override string ToString()
        {
            return $"{this.Birthday}";
        }
    }
}
