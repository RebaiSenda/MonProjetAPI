using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des produits et utilisateurs
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DemoController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new(1, "iPhone 15", 999.99m, "Électronique"),
            new(2, "MacBook Pro", 2499.99m, "Informatique"),
            new(3, "AirPods Pro", 249.99m, "Audio"),
            new(4, "iPad Air", 599.99m, "Tablette"),
            new(5, "Apple Watch", 399.99m, "Wearable")
        };

        private static readonly List<User> Users = new()
        {
            new(1, "Jean", "Dupont", "jean.dupont@email.com"),
            new(2, "Marie", "Martin", "marie.martin@email.com"),
            new(3, "Pierre", "Durand", "pierre.durand@email.com"),
            new(4, "Sophie", "Lemoine", "sophie.lemoine@email.com")
        };

        /// <summary>
        /// Récupère la liste de tous les produits
        /// </summary>
        /// <returns>Liste des produits</returns>
        /// <response code="200">Liste des produits récupérée avec succès</response>
        [HttpGet("products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public IActionResult GetProducts() => Ok(Products);

        /// <summary>
        /// Récupère un produit par son ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns>Le produit correspondant</returns>
        /// <response code="200">Produit trouvé</response>
        /// <response code="404">Produit non trouvé</response>
        [HttpGet("products/{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return product is not null ? Ok(product) : NotFound($"Produit avec l'ID {id} non trouvé");
        }

        /// <summary>
        /// Récupère la liste de tous les utilisateurs
        /// </summary>
        /// <returns>Liste des utilisateurs</returns>
        /// <response code="200">Liste des utilisateurs récupérée avec succès</response>
        [HttpGet("users")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public IActionResult GetUsers() => Ok(Users);

        /// <summary>
        /// Récupère un utilisateur par son ID
        /// </summary>
        /// <param name="id">ID de l'utilisateur</param>
        /// <returns>L'utilisateur correspondant</returns>
        /// <response code="200">Utilisateur trouvé</response>
        /// <response code="404">Utilisateur non trouvé</response>
        [HttpGet("users/{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user is not null ? Ok(user) : NotFound($"Utilisateur avec l'ID {id} non trouvé");
        }

        /// <summary>
        /// Récupère les statistiques de l'API
        /// </summary>
        /// <returns>Statistiques générales</returns>
        /// <response code="200">Statistiques récupérées avec succès</response>
        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStats() => Ok(new
        {
            TotalProducts = Products.Count,
            TotalUsers = Users.Count,
            Categories = Products.Select(p => p.Category).Distinct(),
            AveragePrice = Products.Average(p => p.Price),
            ServerTime = DateTime.UtcNow
        });
    }
}