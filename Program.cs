using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(options => options.UseInMemoryDatabase("ProductDB"));

var app = builder.Build();

//Config Middleware
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

//Initial data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();

    //add products
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product
            {
                Name = "Laptop - byD",
                Price = 999.99m,
                Stock = 10
            },
            new Product
            {
                Name = "Mouse - byD",
                Price = 19.99m,
                Stock = 50
            }
        );

        context.SaveChanges();
    }
}

app.Run();
