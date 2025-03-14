using System.ComponentModel.DataAnnotations;

namespace TheBanks.Models
{
// Modèle pour la création d'un compte
    public class AccountCreationModel
    {
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string FirstName { get; set; } = string.Empty; // Prénom de la personne

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string LastName { get; set; } = string.Empty; // Nom de la personne

        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } // Date de naissance de la personne

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; } = string.Empty; // Email de l'utilisateur

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; // Mot de passe de l'utilisateur

        [Required(ErrorMessage = "Le type de compte est obligatoire")]
        public string AccountType { get; set; } = "Savings"; // Type de compte (Savings ou Current)

        [Range(0, double.MaxValue, ErrorMessage = "La ligne de crédit doit être positive.")]
        public double CreditLine { get; set; } // Ligne de crédit pour les comptes courants
    }
}