using System.Text.Json;
using Microsoft.JSInterop;
using TheBanks.Models; // Importation des modèles nécessaires

namespace TheBanks.Services
{
    public class BankService
    {
        private const string StorageKey = "bankData"; // Clé pour le stockage local
        private readonly IJSRuntime _jsRuntime; // Service pour interagir avec JavaScript

        public Bank Bank { get; private set; } = new Bank("The Bank"); // Instance de la banque

        // Constructeur qui initialise le service
        public BankService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime; // Injection du service IJSRuntime
            LoadBankData(); // Chargement des données de la banque
        }

        // Méthode pour charger les données de la banque depuis le stockage local
        private async void LoadBankData()
        {
            var json = await _jsRuntime.InvokeAsync<string>("storage.load", StorageKey); // Récupère les données
            if (!string.IsNullOrEmpty(json))
            {
                Bank = JsonSerializer.Deserialize<Bank>(json) ?? new Bank("The Bank"); // Désérialise les données
            }
        }

        // Méthode pour sauvegarder les données de la banque dans le stockage local
        public async Task SaveBankData()
        {
            var json = JsonSerializer.Serialize(Bank); // Sérialise l'objet Bank en JSON
            await _jsRuntime.InvokeVoidAsync("storage.save", StorageKey, json); // Sauvegarde dans le stockage local
        }

        // Méthode pour ajouter un compte à la banque
        public async Task AddAccount(Account account) // Ajout de async ici
        {
            Bank.AddAccount(account); // Ajoute le compte à la banque
            await SaveBankData(); // Sauvegarde les données après ajout
        }
    }
}