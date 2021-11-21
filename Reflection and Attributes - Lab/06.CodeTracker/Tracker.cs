using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {

        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var item in methods)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{item.Name} is writteb by {attr.Name}");
                    }
                }
            }
        }
    }
}
