using Microsoft.AspNetCore.Mvc;
using ProductsWeb.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProductsWeb.Controllers
{
    // Controller for handling web requests related to products.
    public class ProductsController : Controller
    {
        // HttpClient instance to make HTTP requests to the API.
        private readonly HttpClient _httpClient;
        // Base URL for the API, retrieved from configuration settings.
        private readonly string? _apiBaseUrl;

        // Constructor that injects IConfiguration to access configuration settings.
        public ProductsController(IConfiguration configuration)
        {
            // Initialize HttpClient for sending HTTP requests.
            _httpClient = new HttpClient();
            // Retrieve the API base URL from the configuration under "ApiSettings:BaseUrl".
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        // Action method for displaying the list of products.
        public async Task<IActionResult> Index()
        {
            // Send a GET request to the API base URL.
            var response = await _httpClient.GetAsync(_apiBaseUrl);
            // Check if the API request was successful.
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string.
                var content = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response into a list of Product objects.
                var products = JsonSerializer.Deserialize<List<Product>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                // Return the view with the list of products.
                return View(products);
            }
            // Return a Problem result if there was an error retrieving products.
            return Problem("Error al obtener productos");
        }

        // Action method to display the Create Product form.
        public IActionResult Create()
        {
            // Return the Create view.
            return View();
        }

        // Action method to handle form submission for creating a new product.
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            // Check if the submitted model data is valid.
            if (ModelState.IsValid)
            {
                // Serialize the product object to a JSON string.
                var json = JsonSerializer.Serialize(product);
                // Create HTTP content with the JSON payload, setting encoding and media type.
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Send a POST request to the API base URL with the product data.
                var response = await _httpClient.PostAsync(_apiBaseUrl, content);

                // If the API call is successful, redirect to the Index action.
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            // If model state is invalid or API call fails, redisplay the form with the current product data.
            return View(product);
        }
    }
}
