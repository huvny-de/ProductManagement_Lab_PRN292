using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Entities;
using ProductManagement_Lab_PRN292.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Controllers
{
    public class UserManageController : Controller
    {
        private readonly DbIdentity _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        // GET: UserManageController
        public UserManageController(DbIdentity context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public ActionResult Index()
        {

            var listUser = _context.Users.Select(x => new UserManageViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Dob = x.Dob,
            }).ToList();
            return View(listUser);
        }



        // GET: UserManageController/Details/5
        public ActionResult Details(string id)
        {
            var roleDetails = _roleManager.Roles.Where(x => x.Id == id).Select(x => new RoleViewModel
            {
                Id = x.Id,
                RoleName = x.Name
            }).FirstOrDefault();
            return View(roleDetails);
        }

        // GET: UserManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
              
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
