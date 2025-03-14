using System.Collections.Generic;
using System.Linq; // Ajouté pour utiliser LINQ

namespace TheBanks.Models
{
    // Classe représentant une banque gérant des comptes
    public class Bank
    {
        // === Propriétés ===

        // Nom de la banque
        public string Name { get; private set; }

        // Dictionnaire des comptes (clé = numéro de compte, valeur = compte)
        public Dictionary<string, Account> Accounts { get; private set; }

        // === Constructeur ===

        // Constructeur de la classe Bank
        public Bank(string name)
        {
            // Vérifie que le nom de la banque n'est pas null
            Name = name ?? throw new ArgumentNullException(nameof(name));
            // Initialise le dictionnaire des comptes
            Accounts = new Dictionary<string, Account>();
        }

        // === Méthodes ===

        // Ajouter un compte à la banque
        public void AddAccount(Account account)
        {
            // Vérifie que le compte n'est pas null
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            // Vérifie si le numéro de compte existe déjà
            if (Accounts.ContainsKey(account.Number))
                throw new ArgumentException("Un compte avec ce numéro existe déjà.");

            // Ajoute le compte au dictionnaire
            Accounts.Add(account.Number, account);

            // S'abonne à l'événement de solde négatif du compte
            account.NegativeBalanceEvent += HandleNegativeBalance;
        }

        private void HandleNegativeBalance(string obj)
        {
            throw new NotImplementedException();
        }

        // Supprimer un compte de la banque
        public void DeleteAccount(string accountNumber)
        {
            // Vérifie que le numéro de compte n'est pas null
            if (accountNumber == null)
                throw new ArgumentNullException(nameof(accountNumber));

            // Vérifie l'existence du compte
            if (!Accounts.ContainsKey(accountNumber))
                throw new KeyNotFoundException("Ce compte n'existe pas.");

            // Supprime l'abonnement à l'événement avant de retirer le compte
            Accounts[accountNumber].NegativeBalanceEvent -= HandleNegativeBalance;

            // Retire le compte du dictionnaire
            Accounts.Remove(accountNumber);
        }

        // Calculer le solde total d'une personne
        public double GetTotalBalanceForPerson(Person person)
        {
            // Somme des soldes des comptes appartenant à la personne
            return Accounts.Values
                .Where(account => account.Owner == person) // Filtre les comptes par propriétaire
                .Sum(account => account.Balance); // Calcule la somme des soldes
        }

        // === Gestion des événements ===

        // Méthode appelée quand un compte passe en négatif
        private void HandleNegativeBalance(Account account)
        {
            // Affiche un message d'avertissement dans la console
            Console.WriteLine($"⚠️ Solde négatif détecté : " +
                              $"Compte {account.Number} (Propriétaire : {account.Owner.FirstName} {account.Owner.LastName})");
        }
    }
}