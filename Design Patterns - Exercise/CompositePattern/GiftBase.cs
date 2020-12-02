using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public abstract class GiftBase
    {
        protected string _name;
        protected int _price;

        public GiftBase(string name, int price)
        {
            this._name = name;
            this._price = price;
        }

        public abstract int CalculateTotalPrice();
    }
}
