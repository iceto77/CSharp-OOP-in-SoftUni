using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Spy
    {

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var item in classMethods.Where(x => x.Name.StartsWith("get")))
            {
                result.AppendLine($"{item.Name} will return {item.ReturnType}");
            }
            foreach (var item in classMethods.Where(x => x.Name.StartsWith("set")))
            {
                result.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
