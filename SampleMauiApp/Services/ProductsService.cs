using RazorClassLibrary1;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace SampleMauiApp.Services
{
    public class ProductsService: IProductsService
    {
        private readonly HttpClient _httpClient;
        public ProductsService(HttpClient httpClient) {

            this._httpClient = httpClient;

        }
        public ProductsService(IServiceCollection services) { }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>($"/Product/getCategories");
            if (result != null)
                Categories = result;
            throw new Exception("Categories not found!");
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Product[]>("/Product/getProducts");
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var result =  await _httpClient.GetFromJsonAsync<Product>($"/Product/{id}");
            if (result != null)
                return result;
            throw new Exception("Product not found!");

        }

        List<Category> IProductsService.Categories()
        {
            throw new NotImplementedException();
        }

        List<Product> IProductsService.Products()
        {
            throw new NotImplementedException();
        }
    }
}
