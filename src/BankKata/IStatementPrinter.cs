using System.Collections.Generic;

namespace BankKata
{
    public interface IStatementPrinter
    {
        void Print(IList<Transaction> transactions);
    }
}