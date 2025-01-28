
using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

                var produts = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (produts == null) return;

                context.Products.AddRange(produts);

                await context.SaveChangesAsync();
            }
        }
    }
}
