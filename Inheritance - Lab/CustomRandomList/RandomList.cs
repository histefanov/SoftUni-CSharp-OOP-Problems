using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var rand = new Random();
            var index = rand.Next(0, this.Count);
            var stringToRemove = this[index];
            this.RemoveAt(index);
            return stringToRemove;
        }
    }
}
