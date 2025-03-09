using System.ComponentModel.DataAnnotations;

// Modèle pour les informations d'identification de connexion
public class LoginCredentials
{
    // Propriété pour l'email de l'utilisateur
    [Required(ErrorMessage = "L'email est obligatoire")] // Validation pour s'assurer que l'email est fourni
    [EmailAddress(ErrorMessage = "Format d'email invalide")] // Validation pour s'assurer que l'email a un format valide
    public string Email { get; set; } = string.Empty; // Initialisé à une chaîne vide

    // Propriété pour le mot de passe de l'utilisateur
    [Required(ErrorMessage = "Le mot de passe est obligatoire")] // Validation pour s'assurer que le mot de passe est fourni
    [DataType(DataType.Password)] // Indique que ce champ est un mot de passe
    public string Password { get; set; } = string.Empty; // Initialisé à une chaîne vide
}