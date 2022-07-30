using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder mb) 
        {
            mb.Entity<Category>().HasKey(x => x.CategoryId);

            mb.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            mb.Entity<Product>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            mb.Entity<Product>().Property(c => c.Description).HasMaxLength(255).IsRequired();

            mb.Entity<Product>().Property(c => c.ImageURL).HasMaxLength(255).IsRequired();

            mb.Entity<Product>().Property(c => c.Price).HasPrecision(12,2);

            mb.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category {
                    CategoryId = 1,
                    Name = "Material Escolar"
                }, new Category 
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                });



        }
    }
}

