using RazorClassLibrary1;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Services
{
    public class ProductsService: IProductsService
    {
        private readonly HttpClient _httpClient;
        public ProductsService(HttpClient httpClient) {

            this._httpClient = httpClient;

        }
        public ProductsService(IServiceCollection services) { }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Product[]>("/Product/getProducts");
        }
    }
}
