using System.ComponentModel.DataAnnotations;

namespace ProductsWeb.Models
{
    // Represents a product in the web application.
    public class Product
    {
        // Unique identifier for the product.
        public int Id { get; set; }

        // The product's name.
        // This field is required.
        [Required]
        public string Name { get; set; } = string.Empty;

        // A brief description of the product.
        // This field is optional.
        public string? Description { get; set; }

        // The product's price.
        // This field is required and must be at least 0.01.
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        // The available stock quantity for the product.
        // This field is required and must be 0 or greater.
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
