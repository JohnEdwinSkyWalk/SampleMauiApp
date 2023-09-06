﻿using RazorClassLibrary1;

namespace BlazorApp1.Client.Services
{
    public interface IProductsService
    {
        List<Product> Products();
        List<Category> Categories();
        Task GetCategories();
        Task<IEnumerable<Product>> GetProductsAsync(); 
        Task<Product> GetProductAsync(int id); 
    }
}
