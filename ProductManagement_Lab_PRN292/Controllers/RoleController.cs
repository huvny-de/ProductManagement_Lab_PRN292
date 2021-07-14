using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {
        private readonly DbProductManagement _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, DbProductManagement context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
        public ActionResult Details(int id)
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
            string name = collection["RoleName"];
            try
            {
                bool isExist = await _roleManager.RoleExistsAsync(name);
                if (isExist)
                {
                    SetAlert(String.Format("Role Name Was Existed: {0}", name), 2);
                    return RedirectToAction(nameof(Create));

                }
                else
                {
                    var role = new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = collection["RoleName"],
                        NormalizedName = collection["RoleName"],
                        ConcurrencyStamp = null,
                    };
                    var result = await _roleManager.CreateAsync(role);
                    SetAlert(String.Format("Create New Role Successfully: {0}", name), 1);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RoleController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

            if (id == null)
            {
                SetAlert("Not Found Role", 2);
                return RedirectToAction(nameof(Index));
            }
            if (await IsAdmin(id))
            {
                SetAlert("Cannot Edit This Role", 3);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var roleDetail = _roleManager.Roles.Where(x => x.Id == id)
                   .Select(x => new RoleViewModel
                   {
                       Id = x.Id,
                       RoleName = x.Name
                   }).FirstOrDefault();
                return View(roleDetail);
            }
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(string id, IFormCollection collection)
        {

            string name = collection["RoleName"];
            var check = await _roleManager.FindByIdAsync(id);
            //bool isExist = await _roleManager.RoleExistsAsync(name);

            if (id == null || check == null)
            {
                SetAlert("Not Found Role", 2);
                return RedirectToAction(nameof(Index));
            }
            if (await IsExistRoleName(name))
            {
                SetAlert(String.Format("Role Name Was Existed: {0}", name), 2);
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                try
                {
                    var role = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
                    role.Name = collection["RoleName"];
                    role.NormalizedName = collection["RoleName"];
                    var result = await _roleManager.UpdateAsync(role);
                    SetAlert("Update Role Successfully", 1);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }


        // GET: RoleController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                SetAlert("Not Found Role", 2);
                return RedirectToAction(nameof(Index));
            }
            if (await IsAdmin(id))
            {
                SetAlert("Cannot Delete This Role", 3);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var roleDetail = _roleManager.Roles.Where(x => x.Id == id)
                      .Select(x => new RoleViewModel
                      {
                          Id = x.Id,
                          RoleName = x.Name
                      }).FirstOrDefault();
                return View(roleDetail);
            }
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

                    SetAlert(String.Format("Cannot Delete Role: {0}", role.Name), 3);

                    return RedirectToAction(nameof(Index));
                }
                if (role == null)
                {
                    SetAlert("Not Found Role", 3);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    SetAlert("Delete Successfully", 1);
                    await _roleManager.DeleteAsync(role);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }
        // GET : User With Role
     
        // Extend Prod
        public async Task<bool> IsAdmin(string id)
        {
            var isAdmin = (await _roleManager.FindByIdAsync(id)).Name;
            return isAdmin.Equals("Administrator");
        }
        public async Task<bool> IsExistRoleName(string name)
        {
            return await _roleManager.RoleExistsAsync(name);
        }
    }
}
