using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.Controllers
{
    // Marks the class as an API controller which provides automatic HTTP response behavior.
    [ApiController]
    // Sets the base route for all actions in this controller to "api/Products" (using the controller's name).
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // A static list to simulate a data store for products.
        // In a real application, this would be replaced by a database or repository.
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-end laptop", Price = 1299.99m, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Description = "Wireless mouse", Price = 29.99m, Stock = 50 }
        };

        // GET: api/Products
        // Retrieves the list of all products.
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Returns HTTP 200 OK with the list of products.
            return Ok(_products);
        }

        // GET: api/Products/{id}
        // Retrieves a specific product by its ID.
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            // Search for the product in the list by matching the provided ID.
            var product = _products.FirstOrDefault(p => p.Id == id);
            // If the product is not found, return HTTP 404 Not Found.
            if (product == null)
                return NotFound();

            // Return HTTP 200 OK with the found product.
            return Ok(product);
        }

        // POST: api/Products
        // Creates a new product and adds it to the list.
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            // Automatically assign a new ID by taking the maximum existing ID and incrementing it.
            product.Id = _products.Max(p => p.Id) + 1;
            // Add the new product to the list.
            _products.Add(product);
            // Returns HTTP 201 Created, along with the route to access the newly created product.
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Products/{id}
        // Updates an existing product with new data.
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            // Find the existing product by its ID.
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            // If the product is not found, return HTTP 404 Not Found.
            if (existingProduct == null)
                return NotFound();

            // Update the product properties with the new values.
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            // Return HTTP 204 No Content indicating the update was successful.
            return NoContent();
        }

        // DELETE: api/Products/{id}
        // Deletes a product by its ID.
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Locate the product by ID.
            var product = _products.FirstOrDefault(p => p.Id == id);
            // If the product does not exist, return HTTP 404 Not Found.
            if (product == null)
                return NotFound();

            // Remove the product from the list.
            _products.Remove(product);
            // Return HTTP 204 No Content indicating the deletion was successful.
            return NoContent();
        }
    }
}
