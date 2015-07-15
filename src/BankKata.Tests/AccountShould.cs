using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class AccountShould
    {
        private const int DepositAmount = 1000;
        private const int WithdrawalAmount = 100;

        private Mock<ITransactionRepository> _transactionRepository;
        private Mock<IStatementPrinter> _statementPrinter;
        private IAccount _account;

        [SetUp]
        public void Initialise_Test()
        {
            _transactionRepository = new Mock<ITransactionRepository>();
            _statementPrinter = new Mock<IStatementPrinter>();

            _account = new Account(_transactionRepository.Object, _statementPrinter.Object);
        }

        [Test]
        public void Process_A_Deposit_Transaction()
        {
            _account.Deposit(DepositAmount);

            _transactionRepository.Verify(x => x.AddDeposit(DepositAmount));
        }
        
        [Test]
        public void Process_A_Withdrawal_Transaction()
        {
            _account.Withdraw(WithdrawalAmount);

            _transactionRepository.Verify(x => x.AddWithdrawal(-WithdrawalAmount));
        }

        [Test]
        public void Print_Statement_With_All_Transactions()
        {
            var transactions = GetTransactions();

            _transactionRepository.Setup(x => x.AllTransactions()).Returns(transactions);

            _account.PrintStatement();

            _transactionRepository.Verify(x => x.AllTransactions());
            _statementPrinter.Verify(x => x.Print(transactions));
        }

        private static List<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("01/04/2014", 1000),
                new Transaction("02/04/2014", -100),
                new Transaction("10/04/2014", 500)
            };
            return transactions;
        }
    }
}
