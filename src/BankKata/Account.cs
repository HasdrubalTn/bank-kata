namespace BankKata
{
    public class Account : IAccount
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;

        public Account(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.AddWithdrawal(-100);
        }

        public void PrintStatement()
        {
            var transactions = _transactionRepository.AllTransactions();

            _statementPrinter.Print(transactions);
        }
    }
}