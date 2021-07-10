using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.DbContexts
{
<<<<<<< HEAD:ProductManagement_Lab_PRN292/DbContexts/DbIdentity .cs
    public class DbIdentity : DbContext
    {
        public DbIdentity(DbContextOptions<DbIdentity> options) : base(options) { }
=======
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }
>>>>>>> hieulh:ProductManagement_Lab_PRN292/DbContexts/WebContext.cs
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
