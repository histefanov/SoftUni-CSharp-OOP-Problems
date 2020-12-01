using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> _transactions;

        public Chainblock()
        {
            this._transactions = new List<ITransaction>();
        }

        public Chainblock(List<ITransaction> transactions)
        {
            this._transactions = new List<ITransaction>(transactions);
        }

        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this._transactions.Any(t => t.Id == tx.Id))
            {
                throw new InvalidOperationException("Transaction with this ID already exists.");
            }

            this._transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var locatedTransaction = this._transactions.FirstOrDefault(t => t.Id == id);

            if (locatedTransaction == null)
            {
                throw new ArgumentException("Transaction with this ID does not exist.");
            }

            locatedTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this._transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            return this._transactions.Any(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this._transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this._transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var foundResult = this._transactions
                .Where(t => t.Status == status)
                .ToList();

            if (foundResult.Count == 0)
            {
                throw new InvalidOperationException("No transactions with the given status were found.");
            }

            var receivers = new Dictionary<string, int>();
            var result = new List<string>();

            foreach (var receiver in foundResult.Select(t => t.To))
            {
                if (!receivers.ContainsKey(receiver))
                {
                    receivers.Add(receiver, 0);
                }
                receivers[receiver]++;
            }

            foreach (var receiver in receivers.OrderByDescending(r => r.Value))
            {
                for (int i = 0; i < receiver.Value; i++)
                {
                    result.Add(receiver.Key);
                }
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var foundResult = this._transactions
                .Where(t => t.Status == status)
                .ToList();

            if (foundResult.Count == 0)
            {
                throw new InvalidOperationException("No transactions with the given status were found.");
            }

            var senders = new Dictionary<string, int>();
            var result = new List<string>();

            foreach (var sender in foundResult.Select(t => t.From))
            {
                if (!senders.ContainsKey(sender))
                {
                    senders.Add(sender, 0);
                }
                senders[sender]++;
            }

            foreach (var sender in senders.OrderByDescending(s => s.Value))
            {
                for (int i = 0; i < sender.Value; i++)
                {
                    result.Add(sender.Key);
                }
            }

            return result;
        }

        public ITransaction GetById(int id)
        {
            var transactionFound = this._transactions.Find(t => t.Id == id);

            if (transactionFound == null)
            {
                throw new InvalidOperationException("Transaction with given ID does not exist.");
            }

            return transactionFound;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = this._transactions
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count ==0)
            {
                throw new InvalidOperationException("No matching transactions were found.");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = this._transactions
                .Where(t => t.To == receiver)
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No transactions with the given reciever were found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var result = this._transactions
                .Where(t => t.From == sender && t.Amount >= amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No matching transactions were found.");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = this._transactions
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No transactions with the given sender were found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Transaction database is empty.");
            }

            return this._transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this._transactions
                .Where(t => t.Status == status &&
                            t.Amount <= amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            var transactionToRemove = this._transactions.FirstOrDefault(t => t.Id == id);

            if (transactionToRemove == null)
            {
                throw new ArgumentException("Transaction with given ID does not exist.");
            }

            this._transactions.Remove(transactionToRemove);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
