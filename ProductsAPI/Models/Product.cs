using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    // Represents a product in the Products API.
    public class Product
    {
        // Unique identifier for the product.
        public int Id { get; set; }

        // The name of the product.
        // This property is required.
        [Required]
        public string Name { get; set; } = string.Empty;

        // A brief description of the product.
        // This property is optional.
        public string? Description { get; set; }

        // The price of the product.
        // This property is required and must be at least 0.01.
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        // The available stock quantity of the product.
        // This property is required and must be at least 0.
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
