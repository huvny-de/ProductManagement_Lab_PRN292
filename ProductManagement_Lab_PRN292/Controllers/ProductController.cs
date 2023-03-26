using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;
using ProductManagement_Lab_PRN292.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Controllers
{
    [Authorize(Roles = "Administrator,Manager,Editor,Host")]

    public class ProductController : Controller
    {
        private readonly DbProductManagement _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(DbProductManagement context, IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
            _context = context;
        }
        //SetAlert
        public void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            IQueryable<string> cateName = from c in _context.Categories
                                          orderby c.CategoryId
                                          select c.CategoryName;
            var categories = new SelectList(await cateName.Distinct().ToListAsync());
            return View(GetModel(categories, await _context.Products.Include(p => p.Category).ToListAsync()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString, string productCategory)
        {
            // Use LINQ to get list of genres.

            IQueryable<string> cateName = from c in _context.Categories
                                          orderby c.CategoryId
                                          select c.CategoryName;

            var products = from m in _context.Products
                           select m;

            // search only
            if (!string.IsNullOrEmpty(searchString) && productCategory.Equals("all"))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
                var categories = new SelectList(cateName.Distinct().ToList());
                return View(GetModel(categories, await products.Include(p => p.Category).ToListAsync()));
            }
            if (string.IsNullOrEmpty(searchString) && productCategory.Equals("all"))
            {
                SetAlert("Input Seach Name", 2);
                return RedirectToAction(nameof(Index));
            }
            // get cate only
            if (string.IsNullOrEmpty(searchString) && !productCategory.Equals("all"))
            {
                products = products.Where(x => x.Category.CategoryName == productCategory);
                var categories = new SelectList(cateName.Distinct().ToList());
                return View(GetModel(categories, await products.Include(p => p.Category).ToListAsync()));

            }
            // search product in category
            else
            {
                products = products.Where(x => x.Category.CategoryName == productCategory)
                    .Where(s => s.ProductName.Contains(searchString));
                var categories = new SelectList(await cateName.Distinct().ToListAsync());
                return View(GetModel(categories, await products.Include(p => p.Category).ToListAsync()));
            }
        }
        public ListProductByCategoryViewModel GetModel(SelectList categories, List<Product> products)
        {
            var productByCategory = new ListProductByCategoryViewModel
            {
                Categories = categories,
                Products = products
            };
            return productByCategory;
        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: ProductsController/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Description,Price,Amount,Photo,CategoryId")] Product product, IFormFile hinhanh)
        {
            if (hinhanh == null || hinhanh.Length == 0)
            {
                return Content("please select file");
            }
            if (ModelState.IsValid)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", hinhanh.FileName);
                var stream = new FileStream(path, FileMode.Create);
                _ = hinhanh.CopyToAsync(stream);
                product.Photo = hinhanh.FileName;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ProductId,ProductName,Description,Price,Amount,Photo,CategoryId")] Product product, IFormFile hinhanh, string hinhanhcu)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (hinhanh == null || hinhanh.Length == 0)
                    {
                        product.Photo = hinhanhcu;
                    }
                    else
                    {
                        var path = Path.Combine(webHostEnvironment.WebRootPath, "images", hinhanh.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        _ = hinhanh.CopyToAsync(stream);
                        product.Photo = hinhanh.FileName;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

    }
}
