using RazorClassLibrary1;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Services
{
    public class ProductsService: IProductsService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ProductsService(HttpClient httpClient, NavigationManager navigationManager) {

            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }
        public ProductsService(IServiceCollection services) { }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategoriesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>($"/Product/getCategories");
            if (result != null)
                Categories = result;
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
            return Categories;
        }

        List<Product> IProductsService.Products()
        {
            return Products;
        }

        public async Task<Product> PutProductAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"/Product/{id}");
            if (result != null)
                return result;
            throw new Exception("Product not found!");

        }

        public async Task CreateProductAsync(Product product)
        {
            var result =  await _httpClient.PostAsJsonAsync($"/Product/createProduct", product);
              setProductAsync(result);
        }

        public async Task updateProductAsync(Product product)
        {
            var result = await _httpClient.PutAsJsonAsync($"/Product/updateProduct", product);
             setProductAsync(result);
        }

        public async Task deleteProductAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"/Product/{id}");
            setAfterDelProductAsync(result);
        }
        public void setProductAsync(HttpResponseMessage result)
        {
            _navigationManager.NavigateTo("Products");
        }
        public async Task setAfterDelProductAsync(HttpResponseMessage result)
        {

            var response = await result.Content.ReadFromJsonAsync<List<Product>>();
            Products = response;
            _navigationManager.NavigateTo("Products");
        }
    }
}
