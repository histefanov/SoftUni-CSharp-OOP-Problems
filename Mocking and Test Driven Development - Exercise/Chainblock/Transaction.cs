using System;
using System.Collections.Generic;
using System.Text;

using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int _id;
        private string _from;
        private string _to;
        private double _amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => this._id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Transaction ID cannot be a negative integer.");
                }
                this._id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this._from;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name cannot be null or whitespace.");
                }
                this._from = value;
            }
        }
        public string To
        {
            get => this._to;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Recipient name cannot be null or whitespace.");
                }
                this._to = value;
            }
        }
        public double Amount
        {
            get => this._amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Transaction amount cannot be zero or negative.");
                }
                this._amount = value;
            }
        }
    }
}
