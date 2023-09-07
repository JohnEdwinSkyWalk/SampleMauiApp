using Microsoft.AspNetCore.Mvc;
using RazorClassLibrary1;

namespace WebApi1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getProducts()
        {
            var products = await  _dataContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(products);
        }

        private async Task<ActionResult<List<RazorClassLibrary1.Product>>> getDbAllProducts()
        {
            return await _dataContext.Products.Include(x => x.Category).ToListAsync();
        }

        [HttpGet]//("categories")
        [Route("getCategories")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RazorClassLibrary1.Product>>> getProductById(int id)
        {
            try
            {
                var product = await _dataContext.Products
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(pr => pr.Id == id);
                if (product == null)
                {
                    return NotFound("Sorry! No products found here..");
                }

                return Ok(product);
            }
            catch(Exception ex)
            {
                return NotFound($"Sorry! No products found here.. {ex.ToString()}");
            }
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<ActionResult<List<Product>>> createProduct(Product product)
        {
                product.Category = null;
                _dataContext.Products.Add(product);
                await _dataContext.SaveChangesAsync();
                return Ok(await getDbAllProducts());

                throw new Exception($"Sorry! Failed to add");
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<ActionResult<List<Product>>> updateProduct(Product editedproduct)
        {
            var product = await _dataContext.Products
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(pr => pr.Id == editedproduct.Id);
            if(product == null)
                return NotFound("Sorry! No such product found for update..");
            product.Name= editedproduct.Name;
            product.Price = editedproduct.Price;
            product.Quantity= editedproduct.Quantity;
            product.Brand = editedproduct.Brand;
            product.CategoryId= editedproduct.CategoryId;

            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await getDbAllProducts());

            throw new Exception($"Sorry! Failed to update");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> deleteProduct(int Id)
        {
            var product = await _dataContext.Products
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(pr => pr.Id == Id);
            if (product == null)
                return NotFound("Sorry! No such product found for delete..");
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await getDbAllProducts());

            throw new Exception($"Sorry! Failed to delete");
        }
    }
}
