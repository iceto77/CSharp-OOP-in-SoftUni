using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            var newList = new List<string>();
            newList.Add("hello");
            newList.Add("my");
            newList.Add("friend");
            myStack.AddRange(newList);

        }
    }
}
