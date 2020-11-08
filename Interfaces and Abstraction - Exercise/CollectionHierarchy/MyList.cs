using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used { get => collection.Count; }

        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var element = collection[0];
            collection.Remove(element);
            return element;
        }
    }
}
