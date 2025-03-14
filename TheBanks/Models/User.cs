using System.ComponentModel.DataAnnotations;

namespace TheBanks.Models
{
    public class User : Person 
    {
        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "8 caractères minimum")]
        public string Password { get; set; } = string.Empty;
        
        
    }
}