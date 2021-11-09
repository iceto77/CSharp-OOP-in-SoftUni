using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IName
    {
        public string Name { get; set; }
    }
    public interface IIdentity
    {
        public string Id { get; set; }
    }
    public interface IBirthday
    {
        public string Birthday { get; set; }
    }
}