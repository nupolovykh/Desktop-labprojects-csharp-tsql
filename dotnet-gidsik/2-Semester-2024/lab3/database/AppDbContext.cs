using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.database
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Wood"},
                new Material { Id = 2, Name = "Steel"},
                new Material { Id = 3, Name = "Сotton" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chair", Price = 4000, MaterialId = 1},
                new Product { Id = 2, Name = "Sofa", Price = 6000, MaterialId = 1 },
                new Product { Id = 3, Name = "Fridge", Price = 9000, MaterialId = 2 },
                new Product { Id = 4, Name = "Stove", Price = 14000, MaterialId = 2 },
                new Product { Id = 5, Name = "Shirt", Price = 1000, MaterialId = 3 },
                new Product { Id = 6, Name = "Panty", Price = 500, MaterialId = 3 });
        }
    }
}
