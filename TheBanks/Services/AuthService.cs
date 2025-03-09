using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Ajout de l'espace de noms pour les tâches
using TheBanks.Models; // Importation des modèles nécessaires

// Service pour gérer l'authentification des utilisateurs
namespace TheBanks.Services
{
    public class AuthService
    {
        private List<User> Users { get; set; } = new List<User>(); // Liste des utilisateurs

        // Constructeur pour initialiser le service avec des utilisateurs par défaut
        public AuthService()
        {
            // Ajoutez des utilisateurs par défaut pour les tests
            Users.Add(new User { Email = "test@example.com", Password = "password123", FirstName = "Test", LastName = "User ", BirthDate = new DateTime(1990, 1, 1) });
        }

        // Méthode pour se connecter (asynchrone)
        public async Task<bool> Login(string email, string password)
        {
            // Simule une opération asynchrone (par exemple, appel à une API)
            await Task.Delay(100); // Simule un délai pour l'authentification

            // Vérifie si l'utilisateur existe et si le mot de passe est correct
            var user = Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null; // Retourne vrai si l'utilisateur est authentifié
        }

        // Méthode pour enregistrer un nouvel utilisateur
        public void Register(string email, string password, string firstName, string lastName, DateTime birthDate)
        {
            // Vérifiez si l'utilisateur existe déjà
            if (Users.Any(u => u.Email == email))
            {
                throw new InvalidOperationException("Un utilisateur avec cet email existe déjà."); // Lève une exception si l'utilisateur existe
            }

            // Ajoutez le nouvel utilisateur
            Users.Add(new User { Email = email, Password = password, FirstName = firstName, LastName = lastName, BirthDate = birthDate });
        }
    }
}