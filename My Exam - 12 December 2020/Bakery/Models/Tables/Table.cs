using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        // private int tableNumber;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople { get; private set; }

        public decimal PricePerPerson { get; }

        public bool IsReserved => NumberOfPeople > 0;

        public decimal Price => NumberOfPeople * PricePerPerson;

        public void Clear()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foodOrders.Sum(f => f.Price) +
                   this.drinkOrders.Sum(d => d.Price) +
                   Price;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}"); // CHANGED TO F2

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            // check if is reserved?  
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }

            NumberOfPeople = numberOfPeople;
        }
    }
}
