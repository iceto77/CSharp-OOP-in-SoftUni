using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
    }
    public interface IIdentifiable
    {
        public string Id { get; }
    }
    public interface IBirthable
    {
        public string Birthdate { get; }
    }
}
