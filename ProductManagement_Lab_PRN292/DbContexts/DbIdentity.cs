using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.DbContexts
{
    public class DbIdentity : IdentityDbContext<AppUser>
    {
        public DbIdentity(DbContextOptions<DbIdentity> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //var roleAdminId = new Guid("A0423453-2858-484F-A934-18A2FFE21AA2");
            //var roleEditorId = new Guid("364A3D9B-7022-4353-A7B4-904ECED25EB0");

            //var editorId = new Guid("0E71F3E0-6032-4318-A061-BA47B59EEC9A");
            //var adminId = new Guid("1D9A0FF2-564A-4640-91EC-3B8AB38A2785");
            //var pHash = new PasswordHasher<AppUser>();

            //builder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = adminId.ToString(),
            //    FirstName = "Henry",
            //    LastName = "de Aaron",
            //    UserName = "huvny",
            //    NormalizedUserName = "huvny",
            //    Email = "admin@gmail.com",
            //    Dob = new DateTime(1997, 3, 27),
            //    NormalizedEmail = "huvny@gmail.com",
            //    PhoneNumber = "0954683265",
            //    EmailConfirmed = true,
            //    PasswordHash = pHash.HashPassword(null, "Abc123!@#"),
            //    SecurityStamp = Guid.NewGuid().ToString()
            //},
            //new AppUser
            //{
            //    Id = editorId.ToString(),
            //    FirstName = "Jesse",
            //    LastName = "Livermore",
            //    UserName = "Jess",
            //    NormalizedUserName = "Jess",
            //    Email = "Jess@gmail.com",
            //    Dob = new DateTime(1987, 7, 26).Date,
            //    NormalizedEmail = "Jess@gmail.com",
            //    PhoneNumber = "6548521564",
            //    EmailConfirmed = true,
            //    PasswordHash = pHash.HashPassword(null, "Abc123!@#"),
            //    SecurityStamp = Guid.NewGuid().ToString()
            //}
            //);
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Id = roleAdminId.ToString(), Name = "Administrator", NormalizedName = "Administrator", },
            //    new IdentityRole { Id = roleEditorId.ToString(), Name = "Host", NormalizedName = "Editor" }
            //    );
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> { RoleId = roleAdminId.ToString(), UserId = adminId.ToString() },
            //    new IdentityUserRole<string> { RoleId = roleEditorId.ToString(), UserId = editorId.ToString() }
            //    );
        }
    }
}
