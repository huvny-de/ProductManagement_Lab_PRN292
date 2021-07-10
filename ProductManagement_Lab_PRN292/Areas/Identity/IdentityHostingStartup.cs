using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;

[assembly: HostingStartup(typeof(ProductManagement_Lab_PRN292.Areas.Identity.IdentityHostingStartup))]
namespace ProductManagement_Lab_PRN292.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

                services.AddDbContext<DbIdentity>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ConnectionString")));

                services.AddDefaultIdentity<AppUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Lockout.AllowedForNewUsers = false;
                })
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DbIdentity>();
            });
        }
    }
}