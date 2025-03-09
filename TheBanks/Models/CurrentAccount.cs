using System;

// Classe pour les comptes courants
public class CurrentAccount : Account
{
    public double CreditLine { get; private set; } // Limite de crédit

    public CurrentAccount(string number, Person owner, double creditLine) : base(number, owner)
    {
        CreditLine = creditLine; // Initialiser la limite de crédit
    }

    public override void Withdraw(double amount)
    {
        if (Balance + CreditLine < amount)
            throw new InsufficientBalanceException("Limite de crédit dépassée.");
        
        base.Withdraw(amount); // Appeler la méthode de retrait de la classe de base
    }

    // Implémentation de la méthode pour calculer les intérêts
    public override double CalculateInterests()
    {
        return 0; // Pas d'intérêts pour les comptes courants
    }

    // Ajoutez cette méthode si elle est nécessaire
    public double CalculateBalance()
    {
        return Balance; // Retourne le solde actuel
    }
}