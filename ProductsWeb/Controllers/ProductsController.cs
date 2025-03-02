using Microsoft.AspNetCore.Mvc;
using ProductsWeb.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProductsWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiBaseUrl;

        // Inyectamos IConfiguration en el constructor
        public ProductsController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiBaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(products);
            }
            return Problem("Error al obtener productos");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}

