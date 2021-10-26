using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random rand;

        public RandomList()
        {
            rand = new Random();
        }
        //public string ReturnsRandomElement()
        //{
        //    int index = rand.Next(0, Count);
        //    string result = this[index];
        //    return result;
        //}

        //public void RemoveRandomElement()
        //{
        //    int index = rand.Next(0, Count);
        //    RemoveAt(index);
        //}
        public string RandomString()
        {
            int index = rand.Next(0, Count);
            string result = this[index];
            RemoveAt(index);
            return result;
        }
    }
}
