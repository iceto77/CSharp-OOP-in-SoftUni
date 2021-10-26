using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new RandomList();
            myList.Add("1");
            myList.Add("2");
            myList.Add("3");
            myList.Add("4");
            myList.Add("5");
            myList.Add("Ico");
            Console.WriteLine(myList.RandomString());

        }
    }
}
