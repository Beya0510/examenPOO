using System;

// Classe de base pour les comptes bancaires
public abstract class Account
{
    public string Number { get; protected set; } // Numéro de compte
    public double Balance { get; protected set; } // Solde du compte
    public Person Owner { get; protected set; } // Propriétaire du compte

    // Événement pour notifier un solde négatif
    public event Action<string>? NegativeBalanceEvent; // Déclaration nullable

    protected Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
        Balance = 0; // Initialiser le solde à 0
    }

    // Méthode pour déposer de l'argent
    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Le montant doit être supérieur à zéro.");
        
        Balance += amount; // Ajouter le montant au solde
    }

    // Méthode pour retirer de l'argent
    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Le montant doit être supérieur à zéro.");
        
        if (Balance < amount)
        {
            NegativeBalanceEvent?.Invoke($"Tentative de retrait de {amount} sur un solde de {Balance}.");
            throw new InvalidOperationException("Solde insuffisant pour effectuer ce retrait.");
        }
        
        Balance -= amount; // Soustraire le montant du solde
    }

    // Méthode abstraite pour calculer les intérêts
    public abstract double CalculateInterests();
}