using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;
using ProductManagement_Lab_PRN292.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbProductManagement _context;


        //SetAlert

        public HomeController(ILogger<HomeController> logger, DbProductManagement context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index(string keyword, string category)
        {
            IQueryable<string> cateName = from c in _context.Categories
                                          orderby c.CategoryId
                                          select c.CategoryName;
            var categories = await cateName.Distinct().ToListAsync();
            var categoriesSelect = new SelectList(categories);
            var product = await _context.Products.Include(p => p.Category).ToListAsync();
            if (keyword != null)
            {
                product = product.Where(x => x.ProductName.ToLower().Contains(keyword.ToLower())).ToList();
            }
            if (category != null)
            {
                product = product.Where(x => x.Category.CategoryName.Equals(category)).ToList();
            }

            return View(GetModel(categoriesSelect, product, categories));
        }

        public ListProductByCategoryViewModel GetModel(SelectList categoriesSelect, List<Product> products, List<string> Categories)
        {
            var productByCategory = new ListProductByCategoryViewModel
            {
                Categories = categoriesSelect,
                Products = products,
                CategoriesName = Categories
            };
            return productByCategory;
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
