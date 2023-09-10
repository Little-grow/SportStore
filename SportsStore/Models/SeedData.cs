using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext? context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275 },
                    new Product { Name = "LifeHacket", Description = "A boat for one person", Category = "Watersports", Price = 275 },
                    new Product { Name = "Soccer Ball", Description = "A boat for one person", Category = "Soccer", Price = 275 },
                    new Product { Name = "Corner Flags", Description = "A boat for one person", Category = "Soccer", Price = 275 },
                    new Product { Name = "Stadium", Description = "A boat for one person", Category = "Soccer", Price = 275 },
                    new Product { Name = "Thinking Cap", Description = "A boat for one person", Category = "Chess", Price = 275 },
                    new Product { Name = "Unstedy Chair", Description = "A boat for one person", Category = "Chess", Price = 275 },
                    new Product { Name = "Human chess board", Description = "A boat for one person", Category = "Chess", Price = 275 },
                    new Product { Name = "Bling-Bling king", Description = "A boat for one person", Category = "Chess", Price = 275 }
                    );
                context.SaveChanges();
            }
        }
    }
}
