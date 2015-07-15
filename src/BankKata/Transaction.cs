namespace BankKata
{
    public class Transaction
    {
        public string Created { get; private set; }
        public int Amount { get; private set; }

        public Transaction(string created, int amount)
        {
            Created = created;
            Amount = amount;
        }
    }
}