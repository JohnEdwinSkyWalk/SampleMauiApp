using RazorClassLibrary1;

namespace BlazorApp1.Client.Services
{
    public interface IProductsService
    {
        List<Product> Products();
        List<Category> Categories();
        Task GetCategoriesAsync();
        Task<IEnumerable<Product>> GetProductsAsync(); 
        Task<Product> GetProductAsync(int id); 
        Task CreateProductAsync(Product product); 
        Task updateProductAsync(Product product); 
        Task deleteProductAsync(int id); 
    }
}
