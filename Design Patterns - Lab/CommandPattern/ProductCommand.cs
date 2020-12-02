using CommandPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this._product = product;
            this._priceAction = priceAction;
            this._amount = amount;
        }
        
        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                this._product.IncreasePrice(this._amount);
            }
            else
            {
                this._product.DecreasePrice(this._amount);
            }
        }
    }
}
