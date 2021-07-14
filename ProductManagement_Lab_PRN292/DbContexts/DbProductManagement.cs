using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement_Lab_PRN292.Models;

namespace ProductManagement_Lab_PRN292.DbContexts
{
    public class DbProductManagement : DbContext
    {
        public DbProductManagement(DbContextOptions<DbProductManagement> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Category 1" },
            new Category { CategoryId = 2, CategoryName = "Category 2" });
            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "ProductName1", Amount = 100, Price = 200, Photo = "san-pham-1.jpg", CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "ProductName2", Amount = 200, Price = 300, Photo = "san-pham-2.jpg", CategoryId = 2 }
                );
        }
        public DbSet<ProductManagement_Lab_PRN292.Models.UserWithRoleViewModel> UserWithRoleViewModel { get; set; }
    }
}
