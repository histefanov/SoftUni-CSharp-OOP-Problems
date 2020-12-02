using CompositePattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            this._gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;

            Console.WriteLine($"{this._name} contains the following products:");

            foreach (var gift in this._gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }

    }
}
