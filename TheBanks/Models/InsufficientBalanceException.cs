// Exception pour gérer les cas de solde insuffisant
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}