// Classe pour les comptes d'épargne
public class SavingsAccount : Account
{
    public SavingsAccount(string number, Person owner) : base(number, owner)
    {
    }

    // Implémentation de la méthode pour calculer les intérêts
    public override double CalculateInterests() // Ajout du mot-clé override
    {
        return Balance * 0.045; // 4.5% d'intérêts
    }

    // Ajoutez cette méthode si elle est nécessaire
    public double CalculateBalance()
    {
        return Balance; // Retourne le solde actuel
    }
}   