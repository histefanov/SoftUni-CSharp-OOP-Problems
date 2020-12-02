using System;
using System.Collections.Generic;
using System.Text;

using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this._id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                this._id = value;
            }
        }

        public string Manufacturer
        {
            get => this._manufacturer;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                this._manufacturer = value;
            }
        }

        public string Model
        {
            get => this._model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                this._model = value;
            }
        }

        public virtual decimal Price
        {
            get => this._price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this._price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this._overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this._overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return String.Format(SuccessMessages.ProductToString,
                this.OverallPerformance,
                this.Price,
                this.GetType().Name,
                this.Manufacturer,
                this.Model,
                this.Id);
                
        }
    }
}
