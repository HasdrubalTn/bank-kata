using System.Collections.Generic;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IOutputWriter _outputWriter;

        public StatementPrinter(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public void Print(IList<Transaction> transactions)
        {
            PrintStatementHeader();

            PrintStatementLines(FormatStatementLines(transactions));
        }

        private void PrintStatementLines(IList<string> lines)
        {
            foreach (var line in lines)
            {
                _outputWriter.Write(line);
            }
        }

        private static IList<string> FormatStatementLines(IList<Transaction> transactions)
        {
            List<string> lines = new List<string>();

            int balance = 0;

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;

                lines.Add(string.Format("{0} | {1} | {2}", 
                    transaction.Created, 
                    transaction.Amount.ToString("F"),
                    balance.ToString("F")));
            }

            lines.Reverse();

            return lines;
        }

        private void PrintStatementHeader()
        {
            _outputWriter.Write("DATE | AMOUNT | BALANCE");
        }
    }
}