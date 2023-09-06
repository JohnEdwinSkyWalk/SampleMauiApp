using Microsoft.AspNetCore.Mvc;
using RazorClassLibrary1;

namespace WebApi1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        public static List<RazorClassLibrary1.Category> categories = new List<RazorClassLibrary1.Category> { 
            new RazorClassLibrary1.Category { Id = 1, Name = "General" },
            new RazorClassLibrary1.Category { Id = 2, Name = "Grossery" }
        };

        public static List<RazorClassLibrary1.Product> products = new List<RazorClassLibrary1.Product> { 
            new RazorClassLibrary1.Product { Id = 1, Name = "Product 1", Brand = "Brand 1", Price = 1, Quantity = 1, Category = categories[1]  },
            new RazorClassLibrary1.Product { Id = 2, Name = "Product 2", Brand = "Brand 2", Price = 2, Quantity = 2, Category = categories[1]  },
            new RazorClassLibrary1.Product { Id = 3, Name = "Product 3", Brand = "Brand 3", Price = 3, Quantity = 3, Category = categories[1]  },
            new RazorClassLibrary1.Product { Id = 4, Name = "Product 4", Brand = "Brand 4", Price = 4, Quantity = 4, Category = categories[0]  },
            new RazorClassLibrary1.Product { Id = 5, Name = "Product 5", Brand = "Brand 5", Price = 5, Quantity = 5, Category = categories[0]  },
        };
        public ProductController() { }

        [HttpGet]
        [Route("getProducts")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getProducts()
        {
            return Ok(products);
        }

        [HttpGet]//("categories")
        [Route("getCategories")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getCategories()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getProductById(int id)
        {
            try
            {
                var Products = products.FirstOrDefault(pr => pr.Id == id);
                if (Products == null)
                {
                    return NotFound("Sorry! No products found here..");
                }

                return Ok(Products);
            }
            catch(Exception ex)
            {
                return NotFound($"Sorry! No products found here.. {ex.ToString()}");
            }
        }
    }
}
