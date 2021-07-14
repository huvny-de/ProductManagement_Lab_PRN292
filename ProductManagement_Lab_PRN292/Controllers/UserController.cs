using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;
using ProductManagement_Lab_PRN292.Models;

namespace ProductManagement_Lab_PRN292.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {

        private readonly DbProductManagement _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(RoleManager<IdentityRole> roleManager, DbProductManagement context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: User
        public async Task<IActionResult> Index(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            var VM = new UserWithRoleViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = string.Join(",", await _userManager.GetRolesAsync(user))
            };
            List<UserWithRoleViewModel> VMs = new List<UserWithRoleViewModel>();
            VMs.Add(VM);
            return View(VMs.AsEnumerable());

        }
        // POST
        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWithRoleViewModel = await _context.UserWithRoleViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userWithRoleViewModel == null)
            {
                return NotFound();
            }

            return View(userWithRoleViewModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Role")] UserWithRoleViewModel userWithRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWithRoleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userWithRoleViewModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            IQueryable<string> roleName = from r in _roleManager.Roles
                                          orderby r.Id
                                          select r.Name;
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            var roles = new SelectList(await roleName.Distinct().ToListAsync());
            var VM = new UserWithRoleSelectViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                //Role = string.Join(",", await _userManager.GetRolesAsync(user))
                Roles = roles
            };
            //List<UserWithRoleViewModel> VMs = new List<UserWithRoleViewModel>();
            //VMs.Add(VM);
            return View(VM);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(string roleName, UserWithRoleSelectViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                SetAlert("User Already in this Role", 2);
                return RedirectToAction("Index", "UserManage");
            }
            SetAlert("Success", 1);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction("Index", "UserManage");


        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            IList<string> lisRole = await _userManager.GetRolesAsync(user);
            var roles = new SelectList(lisRole);
            var VM = new UserWithRoleSelectViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                //Role = string.Join(",", await _userManager.GetRolesAsync(user))
                Roles = roles
            };
            //List<UserWithRoleViewModel> VMs = new List<UserWithRoleViewModel>();
            //VMs.Add(VM);
            return View(VM);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (roleName.Equals("Administrator"))
            {
                SetAlert("Cannot Remove Administrator Role", 3);
                return RedirectToAction("Index", "UserManage");

            }
            await _userManager.RemoveFromRoleAsync(user, roleName);
            SetAlert("Success", 1);
            return RedirectToAction("Index", "UserManage");

        }

        private bool UserWithRoleViewModelExists(string id)
        {
            return _context.UserWithRoleViewModel.Any(e => e.Id == id);
        }
        //Extend
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
        public async Task<bool> IsAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.IsInRoleAsync(user, "Administrator");
        }
    }
}
