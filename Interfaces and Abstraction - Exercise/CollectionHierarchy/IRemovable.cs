using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IRemovable : IAddable
    {
        public string Remove();
    }
}
