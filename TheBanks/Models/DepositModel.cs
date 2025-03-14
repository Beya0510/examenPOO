using System.ComponentModel.DataAnnotations;

namespace TheBanks.Models
{
    // Modèle pour le dépôt d'argent
    public class DepositModel
    {
        [Required(ErrorMessage = "Sélectionnez un compte")]
        public string AccountNumber { get; set; } = string.Empty; // Numéro de compte

        [Required(ErrorMessage = "Le montant est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0")]
        public double Amount { get; set; } // Montant à déposer
    }
}