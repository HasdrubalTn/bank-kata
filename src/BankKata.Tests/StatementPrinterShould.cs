using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private Mock<IOutputWriter> _outputWriter;
        private IStatementPrinter _statementPrinter;

        [SetUp]
        public void Initialise_Test()
        {
            _outputWriter = new Mock<IOutputWriter>();

            _statementPrinter = new StatementPrinter(_outputWriter.Object);
        }

        [Test]
        public void Print_Statement_With_All_Transactions()
        {
            var transactions = GetTransactions();

            _statementPrinter.Print(transactions);

            _outputWriter.Verify(x => x.Write("DATE | AMOUNT | BALANCE"));
            _outputWriter.Verify(x => x.Write("10/04/2014 | 500.00 | 1400.00"));
            _outputWriter.Verify(x => x.Write("02/04/2014 | -100.00 | 900.00"));
            _outputWriter.Verify(x => x.Write("01/04/2014 | 1000.00 | 1000.00"));
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
