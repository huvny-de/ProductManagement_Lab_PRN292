using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement_Lab_PRN292.DbContexts;
using ProductManagement_Lab_PRN292.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private HomeController _homeController;
        public RoleController(RoleManager<IdentityRole> roleManager, HomeController homeController)
        {
            _roleManager = roleManager;
            _homeController = homeController;
        }
        // GET: RoleController

        public ActionResult Index()
        {
            var listRole = _roleManager.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                RoleName = x.Name
            }
                ).ToList();
            return View(listRole);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                var role = new IdentityRole
                {
                    Id = collection["Id"],
                    Name = collection["Name"],
                    NormalizedName = "",
                    ConcurrencyStamp = "",
                };
                var result = await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(string id)
        {
            var roleDetail = _roleManager.Roles.Where(x => x.Id == id)
                .Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    RoleName = x.Name
                }).FirstOrDefault();
            return View(roleDetail);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(string id, IFormCollection collection)
        {
            try
            {
                var role = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
                role.Name = collection["Name"];
                role.NormalizedName = collection["NormalizedName"];

                var result = await _roleManager.UpdateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(string id)
        {
            var roleDetail = _roleManager.Roles.Where(x => x.Id == id)
                .Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    RoleName = x.Name
                }).FirstOrDefault();
            return View(roleDetail);
        }
        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(string id, IFormCollection collection)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);

                if (role.Name == "Administrator")
                {

                    _homeController.SetAlert("Cannot Delete", 3);
                    return RedirectToAction(nameof(Index));
                }
                if (role == null)
                {
                    _homeController.SetAlert("Not Found Role", 3);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _homeController.SetAlert("Delete Successful", 1);
                    await _roleManager.DeleteAsync(role);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
