namespace TheBanks.Models
{
    // Interface de base pour les comptes bancaires
    public interface IAccount
    {
        // Solde du compte (lecture seule)
        double Balance { get; }

        // Opérations de dépôt et retrait
        void Deposit(double amount);
        void Withdraw(double amount);
    }
}


