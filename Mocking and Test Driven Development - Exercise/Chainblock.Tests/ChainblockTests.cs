using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        [Test]
        public void ChainblockConstructor_ShouldCreateExpectedInstance()
        {
            var transactions = new List<ITransaction>() {
                new Transaction(100, TransactionStatus.Successful, "Pesho", "Gosho", 10),
                new Transaction(101, TransactionStatus.Failed, "Pesho", "Gosho", 100) };

            var chainblock = new Chainblock(transactions);
            
            var innerListOfTransactions = typeof(Chainblock)
                .GetField("_transactions", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(chainblock) as ICollection;
            var expectedCount = 2;
            var actualCount = innerListOfTransactions.Count;

            CollectionAssert.AreEqual(transactions, innerListOfTransactions);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_ShouldAddTransaction_WhenUnique()
        {
            var chainblock = new Chainblock();

            chainblock.Add(new Transaction(
                2, TransactionStatus.Failed, "Pesho", "Ico", 10));

            int expectedCount = 1;
            int actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_ShouldThrowInvOpExc_WhenTransactionWithSameIdExists()
        {
            var chainblock = new Chainblock();
            var transaction1 = new Transaction(13, TransactionStatus.Failed, "Pesho", "Ico", 10);
            var transaction2 = new Transaction(13, TransactionStatus.Aborted, "Tisho", "Ico", 11);

            chainblock.Add(transaction1);

            Assert.Throws<InvalidOperationException>(
                () => chainblock.Add(transaction2));
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenTransactionExists()
        {
            var transaction = new Transaction(12, TransactionStatus.Aborted, "nqkoi", "na nqkogo", 10);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction
            });

            Assert.That(chainblock.Contains(transaction), Is.EqualTo(true));
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenTransactionDoesNotExist()
        {
            var transaction = new Transaction(12, TransactionStatus.Aborted, "nqkoi", "na nqkogo", 10);
            var chainblock = new Chainblock();

            Assert.That(chainblock.Contains(transaction), Is.EqualTo(false));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldWorkAsExpected_WhenTransactionWithGivenIdExists()
        {
            var transaction = new Transaction(12, TransactionStatus.Unauthorized, "ico", "gosho", 10);
            var chainblock = new Chainblock();

            var expectedStatus = TransactionStatus.Successful;
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(12, expectedStatus);

            Assert.AreEqual(expectedStatus, transaction.Status);
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrowArgExc_WhenTransactionWithGivenIdDoesNotExist()
        {
            var chainblock = new Chainblock();

            Assert.Throws<ArgumentException>(
                () => chainblock.ChangeTransactionStatus(1001, TransactionStatus.Failed));
        }

        [Test]
        [TestCase(10, 10, true)]
        [TestCase(10, 11, false)]
        public void ContainsId_ShouldReturnExpectedResult_BothWhenExistsOrNot(
            int id, int idToFind, bool expectedResult)
        {
            var chainblock = new Chainblock();
            chainblock.Add(new Transaction(id, TransactionStatus.Aborted, "ico", "emo", 20));

            var actualResult = chainblock.Contains(idToFind);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveTransactionById_ShouldRemoveTransaction_WhenTransactionIdExists()
        {
            var chainblock = new Chainblock();
            chainblock.Add(new Transaction(1234, TransactionStatus.Failed, "ico", "emo", 10));

            int precount = chainblock.Count;
            chainblock.RemoveTransactionById(1234);
            int postcount = chainblock.Count;

            Assert.That(precount - 1, Is.EqualTo(postcount));
        }

        [Test]
        public void GetById_ShouldReturnExpectedTransaction_WhenIdExists()
        {
            var chainblock = new Chainblock();
            var transaction = new Transaction(1234, TransactionStatus.Failed, "ico", "emo", 10);
            chainblock.Add(transaction);

            var returnedTransaction = chainblock.GetById(1234);

            Assert.AreSame(transaction, returnedTransaction);
        }

        [Test]
        public void GetById_ShouldThrowInvOpExc_WhenIdDoesNotExist()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetById(1234));
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnExpectedCollection_WhenTransactionListNotEmpty()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successful, "ico", "gosho", 15);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "ico", "gosho", 18);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "ico", "gosho", 250);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction1,
                transaction2
            }
            .OrderByDescending(t => t.Amount)
            .ToList();

            var actualResult = chainblock.GetByTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowInvOpEx_WhenCollectionIsEmpty()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnSenders_WhenSuchTransactionsExist()
        {
            var transaction1 = new Transaction(1, TransactionStatus.Failed, "ico", "gosho", 20);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "ico", "gosho", 30);
            var transaction3 = new Transaction(3, TransactionStatus.Aborted, "ico", "gosho", 20);
            var transaction4 = new Transaction(4, TransactionStatus.Failed, "pesho", "gosho", 20);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<string>()
            {
                "ico",
                "ico",
                "pesho"
            };
            var actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowInvOpExc_WhenNoTransactionsAreFound()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnSenders_WhenSuchTransactionsExist()
        {
            var transaction1 = new Transaction(1, TransactionStatus.Failed, "ico", "gosho", 20);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "ico", "tosho", 30);
            var transaction3 = new Transaction(3, TransactionStatus.Aborted, "ico", "gosho", 20);
            var transaction4 = new Transaction(4, TransactionStatus.Failed, "pesho", "tosho", 20);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<string>()
            {
                "tosho",
                "tosho",
                "gosho"
            };
            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowInvOpExc_WhenNoTransactionsAreFound()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void GetAllOrderedByAmoundDescendingThenById_ShouldReturnSortedCollection()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Failed, "ico", "gosho", 45);
            var transaction2 = new Transaction(4323, TransactionStatus.Failed, "ico", "tosho", 900);
            var transaction3 = new Transaction(8875, TransactionStatus.Aborted, "ico", "gosho", 900);
            var transaction4 = new Transaction(3345, TransactionStatus.Failed, "pesho", "tosho", 200);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction2, 
                transaction3, 
                transaction4, 
                transaction1
            };
            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnExpectedResult_WhenSuchTransactionsExist()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Failed, "ico", "gosho", 45);
            var transaction2 = new Transaction(4323, TransactionStatus.Failed, "ico", "tosho", 900);
            var transaction3 = new Transaction(8875, TransactionStatus.Aborted, "pesho", "gosho", 900);
            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction2,
                transaction1
            };
            var actualResult = chainblock.GetBySenderOrderedByAmountDescending("ico");

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowInvOpExc_WhenNoSuchTransactionsExist()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderOrderedByAmountDescending("nonExistantUser"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnExpectedResult_WhenSuchTransactionsExist()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Failed, "ico", "gosho", 250);
            var transaction2 = new Transaction(5323, TransactionStatus.Failed, "ico", "gosho", 900);
            var transaction3 = new Transaction(4323, TransactionStatus.Aborted, "pesho", "gosho", 900);
            var transaction4 = new Transaction(8876, TransactionStatus.Aborted, "pesho", "tisho", 900);
            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction1,
                transaction3,
                transaction2
            };
            var actualResult = chainblock.GetByReceiverOrderedByAmountThenById("gosho");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowInvOpExc_WhenNoSuchTransactionsExist()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverOrderedByAmountThenById("ico"));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnExpectResult_WhenAnyAreFound()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Successful, "ico", "gosho", 700);
            var transaction2 = new Transaction(5323, TransactionStatus.Successful, "ico", "gosho", 800);
            var transaction3 = new Transaction(4323, TransactionStatus.Successful, "pesho", "gosho", 900);
            var transaction4 = new Transaction(8876, TransactionStatus.Aborted, "pesho", "tisho", 900);
            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction2, 
                transaction1
            };
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(
                TransactionStatus.Successful, 850);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenNoneWereFound()
        {
            var chainblock = new Chainblock();

            var expectedResult = new List<ITransaction>();
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 500);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnExpectedCollection_WhenAnyWereFound()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Successful, "ico", "gosho", 700);
            var transaction2 = new Transaction(5323, TransactionStatus.Successful, "ico", "gosho", 800);
            var transaction3 = new Transaction(4323, TransactionStatus.Successful, "ico", "gosho", 900);
            var transaction4 = new Transaction(8876, TransactionStatus.Aborted, "pesho", "tisho", 900);
            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction3,
                transaction2
            };
            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending(
                "ico", 750);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvOpExc_WhenNoneWereFound()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderAndMinimumAmountDescending("ico", 1));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnExpectedCollection_WhenAnyWereFound()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Successful, "ico", "gosho", 500);
            var transaction2 = new Transaction(5323, TransactionStatus.Successful, "ico", "gosho", 540);
            var transaction3 = new Transaction(4323, TransactionStatus.Successful, "ico", "gosho", 600);
            var transaction4 = new Transaction(8876, TransactionStatus.Aborted, "pesho", "tisho", 900);
            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction2,
                transaction1
            };
            var actualResult = chainblock.GetByReceiverAndAmountRange(
                "gosho", 500, 600);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvOpExc_WhenNoneWereFound()
        {
            var chainblock = new Chainblock();

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("ico", 20, 100));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnMatchingTransactions_WhenAnyWereFound()
        {
            var transaction1 = new Transaction(1243, TransactionStatus.Successful, "ico", "gosho", 500);
            var transaction2 = new Transaction(5323, TransactionStatus.Successful, "ico", "gosho", 540);
            var transaction3 = new Transaction(4323, TransactionStatus.Successful, "ico", "gosho", 600);
            var transaction4 = new Transaction(8476, TransactionStatus.Aborted, "pesho", "tisho", 900);
            var transaction5 = new Transaction(8376, TransactionStatus.Aborted, "pesho", "tisho", 1000);
            var transaction6 = new Transaction(88776, TransactionStatus.Aborted, "pesho", "tisho", 1200);

            var chainblock = new Chainblock(new List<ITransaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4,
                transaction5,
                transaction6
            });

            var expectedResult = new List<ITransaction>()
            {
                transaction3,
                transaction4,
                transaction5
            };
            var actualResult = chainblock.GetAllInAmountRange(600, 1000);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
