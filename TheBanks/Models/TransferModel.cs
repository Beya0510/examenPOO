using System.ComponentModel.DataAnnotations;

namespace MyNamespace
{
// Modèle pour les informations de transfert
    public class TransferModel
    {
        [Required(ErrorMessage = "Sélectionnez un compte source")]
        public string SourceAccount { get; set; } = string.Empty; // Compte source pour le transfert

        [Required(ErrorMessage = "Sélectionnez un compte destinataire")]
        public string TargetAccount { get; set; } = string.Empty; // Compte destinataire pour le transfert

        [Required(ErrorMessage = "Le montant est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0")]
        public double Amount { get; set; } // Montant à transférer
    }
}