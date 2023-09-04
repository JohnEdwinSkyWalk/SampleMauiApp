using Microsoft.AspNetCore.Mvc;
using RazorClassLibrary1;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("getProducts")]
        public IActionResult getProducts()
        {
            List<Product> Products = new List<Product>();

            Product product = null;

            product = new Product { Id = 1, Name = "Product 1", Brand = "Brand 1", Price = 1, Quantity = 1 };
            Products.Add(product);
            product = new Product { Id = 2, Name = "Product 2", Brand = "Brand 2", Price = 2, Quantity = 2 };
            Products.Add(product);
            product = new Product { Id = 3, Name = "Product 3", Brand = "Brand 3", Price = 3, Quantity = 3 };
            Products.Add(product);
            product = new Product { Id = 4, Name = "Product 4", Brand = "Brand 4", Price = 4, Quantity = 4 };
            Products.Add(product);
            product = new Product { Id = 5, Name = "Product 5", Brand = "Brand 5", Price = 5, Quantity = 5 };
            Products.Add(product);

            return Ok(Products);
        }
    }
}
