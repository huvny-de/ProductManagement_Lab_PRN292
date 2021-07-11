using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbProductManagement _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(DbProductManagement context, IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
            _context = context;
        }
        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            var webContext = _context.Products.Include(p => p.Category);
            return View(await webContext.ToListAsync());
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
        public ActionResult IndexbyCategory(int categoryId)
        {
            if (_context.Categories.Find(categoryId) == null)
            {

                return RedirectToAction(nameof(Create));
            }
            else
            {
                var listProduct = _context.Products.Where(x => x.CategoryId == categoryId).Select(p => new Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Amount = p.Amount,
                    Price = p.Price,
                    Photo = p.Photo,
                    CategoryId = p.CategoryId

                });
                return View(listProduct);

            }


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
        public async Task<IActionResult> Create([Bind("ProductName,Price,Amount,Photo,CategoryId")] Product product, IFormFile hinhanh)
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
        public async Task<IActionResult> Edit(int? id, [Bind("ProductId,ProductName,Price,Amount,Photo,CategoryId")] Product product, IFormFile hinhanh)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (hinhanh != null || hinhanh.Length != 0)
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
