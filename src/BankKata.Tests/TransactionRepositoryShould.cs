using System.Linq;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private const int DepositAmount = 1000;
        private const int WithdrawalAmount = 100;
        private const string TransactionDate = "01/04/2014";

        private Mock<IClock> _clock;
        private ITransactionRepository _transactionRepository;

        [SetUp]
        public void Initialise_Test()
        {
            _clock = new Mock<IClock>();
            _clock.Setup(x => x.TodayAsString()).Returns(TransactionDate);

            _transactionRepository = new TransactionRepository(_clock.Object);
        }

        [Test]
        public void Create_And_Store_A_Deposit_Transaction()
        {
            _transactionRepository.AddDeposit(DepositAmount);

            var transactions = _transactionRepository.AllTransactions().ToList();

            Assert.That(transactions.Count(), Is.EqualTo(1));
            Assert.That(transactions[0].Created, Is.EqualTo(TransactionDate));
            Assert.That(transactions[0].Amount, Is.EqualTo(DepositAmount));
        }
        
        [Test]
        public void Create_And_Store_A_Withdrawal_Transaction()
        {
            _transactionRepository.AddWithdrawal(WithdrawalAmount);

            var transactions = _transactionRepository.AllTransactions().ToList();

            Assert.That(transactions.Count(), Is.EqualTo(1));
            Assert.That(transactions[0].Created, Is.EqualTo(TransactionDate));
            Assert.That(transactions[0].Amount, Is.EqualTo(WithdrawalAmount));
        }

        [Test]
        public void Get_A_List_Of_All_Transactions()
        {
            _transactionRepository.AddDeposit(DepositAmount);
            _transactionRepository.AddWithdrawal(WithdrawalAmount);

            var transactions = _transactionRepository.AllTransactions();

            Assert.That(transactions.Count(), Is.EqualTo(2));
        }
    }
}
