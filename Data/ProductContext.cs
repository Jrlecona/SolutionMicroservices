using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options) { }
}
