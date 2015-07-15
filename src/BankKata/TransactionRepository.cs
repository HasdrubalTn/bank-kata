using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
        private readonly IClock _clock;

        public TransactionRepository(IClock clock)
        {
            _clock = clock;
        }

        public void AddDeposit(int amount)
        {
            var today = _clock.TodayAsString();

            var transaction = new Transaction(today, amount);

            _transactions.Add(transaction);
        }

        public void AddWithdrawal(int amount)
        {
            var today = _clock.TodayAsString();

            var transaction = new Transaction(today, amount);

            _transactions.Add(transaction);
        }

        public IList<Transaction> AllTransactions()
        {
            return _transactions;
        }
    }
}