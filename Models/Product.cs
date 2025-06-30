using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    /// <summary>
    /// Représente un produit dans le système
    /// </summary>
    /// <param name="Id">Identifiant unique du produit</param>
    /// <param name="Name">Nom du produit</param>
    /// <param name="Price">Prix du produit en euros</param>
    /// <param name="Category">Catégorie du produit</param>
    public record Product(
        [property: Range(1, int.MaxValue, ErrorMessage = "L'ID doit être positif")]
        int Id,

        [property: Required(ErrorMessage = "Le nom est requis")]
        [property: StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        string Name,

        [property: Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        decimal Price,

        [property: Required(ErrorMessage = "La catégorie est requise")]
        [property: StringLength(50, ErrorMessage = "La catégorie ne peut pas dépasser 50 caractères")]
        string Category
    );
}
