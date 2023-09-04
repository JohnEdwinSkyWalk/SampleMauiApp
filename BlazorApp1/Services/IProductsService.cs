using RazorClassLibrary1;

namespace BlazorApp1.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync(); 
    }
}
