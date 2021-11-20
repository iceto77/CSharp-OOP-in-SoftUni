using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {

            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);
            result.AppendLine($"All Private Methods of Class: {classType.FullName}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var item in classMethods)
            {
                result.AppendLine(item.Name);
            }

            return result.ToString().TrimEnd();
        }
    }
}
