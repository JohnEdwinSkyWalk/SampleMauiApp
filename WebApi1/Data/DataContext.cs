

using RazorClassLibrary1;

namespace WebApi1.Server.Data
{
    public class DataContext: DbContext
    {
       public DataContext(DbContextOptions<DataContext> options): base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new RazorClassLibrary1.Category { Id = 1, Name = "General" },
                 new RazorClassLibrary1.Category { Id = 2, Name = "Grossery" }
            );

            modelBuilder.Entity<Product>().HasData(
                new RazorClassLibrary1.Product { Id = 1, Name = "Product 1", Brand = "Brand 1", Price = 1, Quantity = 1,  CategoryId = 2 },
            new RazorClassLibrary1.Product { Id = 2, Name = "Product 2", Brand = "Brand 2", Price = 2, Quantity = 2,  CategoryId = 2 },
            new RazorClassLibrary1.Product { Id = 3, Name = "Product 3", Brand = "Brand 3", Price = 3, Quantity = 3, CategoryId = 2 },
            new RazorClassLibrary1.Product { Id = 4, Name = "Product 4", Brand = "Brand 4", Price = 4, Quantity = 4, CategoryId = 1 },
            new RazorClassLibrary1.Product { Id = 5, Name = "Product 5", Brand = "Brand 5", Price = 5, Quantity = 5, CategoryId = 1 }
                );
        }

        public DbSet<Product> Products { get; set;} 
        
        public DbSet<Category> Categories { get; set;}
    }
}
