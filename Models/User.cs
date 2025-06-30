using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    /// <summary>
    /// Représente un utilisateur dans le système
    /// </summary>
    /// <param name="Id">Identifiant unique de l'utilisateur</param>
    /// <param name="FirstName">Prénom de l'utilisateur</param>
    /// <param name="LastName">Nom de famille de l'utilisateur</param>
    /// <param name="Email">Adresse email de l'utilisateur</param>
    public record User(
        [property: Range(1, int.MaxValue, ErrorMessage = "L'ID doit être positif")]
        int Id,

        [property: Required(ErrorMessage = "Le prénom est requis")]
        [property: StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        string FirstName,

        [property: Required(ErrorMessage = "Le nom est requis")]
        [property: StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        string LastName,

        [property: Required(ErrorMessage = "L'email est requis")]
        [property: EmailAddress(ErrorMessage = "Format d'email invalide")]
        string Email
    );
}