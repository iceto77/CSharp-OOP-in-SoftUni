using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var item in classFields)
            {
                result.AppendLine($"{item.Name} must be private!");
            }
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var item in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                result.AppendLine($"{item.Name} have to be public!");
            }
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var item in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                result.AppendLine($"{item.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }
    }
}
