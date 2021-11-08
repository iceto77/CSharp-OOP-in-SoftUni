using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizens : MyDecision, IIdentity, IBirthday
    {
        private string id;
        private string name;
        private int age;
        private string birthday;

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
