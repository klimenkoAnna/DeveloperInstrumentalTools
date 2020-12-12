using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<ShopCategoryEntity> Summaries { get; set; }
        public DbSet<ShopEntity> Shops { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<ShopEntity>(entity =>
            {
                entity.ToTable("shop");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Category);
            });

            modelBuilder.Entity<ShopCategoryEntity>(entity =>
            {
                entity.ToTable("shop_category");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<ShopCategoryEntity>().HasData(new ShopCategoryEntity { Id = 1, Category = "Supermarket" });
            modelBuilder.Entity<ShopCategoryEntity>().HasData(new ShopCategoryEntity { Id = 2, Category = "Petrol station" });
            modelBuilder.Entity<ShopCategoryEntity>().HasData(new ShopCategoryEntity { Id = 3, Category = "Toy shop" });
         
            
            modelBuilder.Entity<ShopEntity>().HasData(new
            {
                Id = 1,
                ShopCategoryEntity = 1,
                Rating = 4.2,
                Address = "test address",
                SiteLink = "site.com"
            });

            //modelBuilder.Entity<WeatherEntity>().OwnsOne(p => p.Summary).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Code = "Chill" });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
