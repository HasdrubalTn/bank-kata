namespace BankKata
{
    public interface IAccount
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        void PrintStatement();
    }
}