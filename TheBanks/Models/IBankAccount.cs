namespace TheBanks.Models
{
    // Interface étendue pour les comptes gérés par une banque
    public interface IBankAccount : IAccount
    {
        // Numéro du compte
        string Number { get; }

        // Propriétaire du compte
        Person Owner { get; }

        // Méthode pour appliquer les intérêts
        void ApplyInterest();
    }
}