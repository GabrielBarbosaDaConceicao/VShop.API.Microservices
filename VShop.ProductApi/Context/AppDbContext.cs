using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Category Mapping
            builder.Entity<Category>()
                .HasKey(x => x.CategoryId);

            builder.Entity<Category>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                });

            // Product Mapping
            builder.Entity<Product>()
                .HasKey(x => x.Id);

            builder.Entity<Product>()
              .Property(x => x.Name)
              .HasMaxLength(100)
              .IsRequired();

            builder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Entity<Product>()
             .Property(x => x.Description)
             .HasMaxLength(255)
             .IsRequired();

            builder.Entity<Product>()
                .Property(x => x.Stock)
                .HasPrecision(1000)
                .HasDefaultValue(0);

            builder.Entity<Product>()
             .Property(x => x.ImageURL)
             .HasMaxLength(300)
             .IsRequired();

            builder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
