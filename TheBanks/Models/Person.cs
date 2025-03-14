
using System;
using System.ComponentModel.DataAnnotations;

namespace TheBanks.Models
{
    // Classe représentant une personne physique dans le système
    public class Person
    {
        [Key] // Indique que cette propriété est la clé primaire
        public Guid Id { get; set; } = Guid.NewGuid(); // Identifiant unique de la personne

        [Required(ErrorMessage = "Le prénom est obligatoire")] // Validation pour s'assurer que le prénom est fourni
        public string FirstName { get; set; } = string.Empty; // Prénom de la personne

        [Required(ErrorMessage = "Le nom est obligatoire")] // Validation pour s'assurer que le nom est fourni
        public string LastName { get; set; } = string.Empty; // Nom de la personne

        [Required(ErrorMessage = "La date de naissance est obligatoire")] // Validation pour s'assurer que la date de naissance est fournie
        [DataType(DataType.Date)] // Indique que ce champ est une date
        public DateTime BirthDate { get; set; } // Date de naissance de la personne

        // Constructeur sans paramètre
        public Person()
        {
        }

        // Constructeur avec paramètres
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        // Méthode pour vérifier si les informations d'une personne correspondent à celles d'un autre
        public bool Matches(string firstName, string lastName, DateTime birthDate)
        {
            // Compare le prénom, le nom et la date de naissance
            return FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
                   && LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
                   && BirthDate.Date == birthDate.Date; // Compare uniquement la date (sans l'heure)
        }
    }
}