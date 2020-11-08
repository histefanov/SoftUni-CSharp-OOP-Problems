using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    interface IList : IRemovable
    {
        public int Used { get; set; }
    }
}
