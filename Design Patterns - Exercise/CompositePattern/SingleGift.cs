using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        { }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this._name} with price of ${this._price}");

            return this._price;
        }
    }
}
