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
    [Authorize(Roles = "Administrator,Manager")]

    public class UserManageController : Controller
    {
        private readonly DbIdentity _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;


        // GET: UserManageController
        public UserManageController(DbIdentity context, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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
                Lockout = x.LockoutEnabled
            }).ToList();
            return View(listUser);
        }

        //public ActionResult UsersWithRoles()
        //{
        //    //var test = _userManager.Users.Select(x => new UserWithRoleViewModel
        //    //{
        //    //    UserId = x.Id,
        //    //    UserName = x.UserName,
        //    //    Role = _userManager.GetRolesAsync(_userManager.FindByIdAsync(x.Id).Result).Result.ToString()
        //    //}).ToList();
        //    var usersWithRoles = (from user in _userManager.Users
        //                          select new
        //                          {
        //                              UserId = user.Id,
        //                              UserName = user.UserName,
        //                              RoleName = (from userRole in _roleManager.Roles
        //                                          join role in _roleManager.Roles on _
        //                                          equals role.Id
        //                                          select role.Name).ToList()
        //                          }).ToList().Select(p => new UserWithRoleViewModel
        //                          {
        //                              UserId = p.UserId,
        //                              UserName = p.UserName,
        //                              Role = string.Join(",", p.RoleName)
        //                          });
        //    return View(usersWithRoles);
        //}

        // GET: UserManageController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                SetAlert("Not Found User", 2);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var userDetails = _userManager.Users.Where(x => x.Id == id).Select(x => new UserManageViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Dob = x.Dob,
                    Lockout = x.LockoutEnabled
                }).FirstOrDefault();
                return View(userDetails);
            }
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
            string userName = collection["UserName"];
            string email = collection["Email"];
            var isExistUsername = await _userManager.FindByNameAsync(userName);
            var isExistEmail = await _userManager.FindByEmailAsync(email);

            if (isExistUsername != null)
            {
                {
                    SetAlert("UserName Was Existed", 2);
                    return RedirectToAction(nameof(Create));
                }
            }
            else if (isExistEmail != null)
            {
                {
                    SetAlert("Email Was Existed", 2);
                    return RedirectToAction(nameof(Create));
                }
            }
            else
            {
                try
                {
                    var user = new AppUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = collection["UserName"],
                        FirstName = collection["FirstName"],
                        LastName = collection["LastName"],
                        Email = collection["Email"],
                        PhoneNumber = collection["PhoneNumber"],
                        Dob = DateTime.Parse(collection["Dob"]),
                    };
                    var result = await _userManager.CreateAsync(user, collection["Password"]);
                    SetAlert(String.Format("Create New User Successfully: {0}", userName), 1);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        // GET: UserManageController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var isAdmin = await _userManager.IsInRoleAsync(user, "Administrator");
            if (id == null)
            {
                SetAlert("Not Found User", 2);
                return RedirectToAction(nameof(Index));
            }
            if (isAdmin)
            {
                SetAlert("Cannot Edit Admin Information", 3);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var userDetails = _userManager.Users.Where(x => x.Id == id)
                   .Select(x => new UserManageViewModel
                   {
                       UserName = x.UserName,
                       FirstName = x.FirstName,
                       LastName = x.LastName,
                       Email = x.Email,
                       PhoneNumber = x.PhoneNumber,
                       Dob = x.Dob,
                       Lockout = x.LockoutEnabled,
                   }).FirstOrDefault();
                return View(userDetails);
            }
        }

        // POST: UserManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(string id, IFormCollection collection)
        {
            string userName = collection["UserName"];
            string email = collection["Email"];
            var isExistUsername = await _userManager.FindByNameAsync(userName);
            var isExistEmail = await _userManager.FindByEmailAsync(email);
            if (id == null)
            {
                SetAlert("Not Found User", 2);
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                try
                {
                    var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
                    user.UserName = collection["UserName"];
                    user.FirstName = collection["FirstName"];
                    user.LastName = collection["LastName"];
                    user.Dob = DateTime.Parse(collection["Dob"]);
                    user.Email = collection["Email"];
                    user.PhoneNumber = collection["PhoneNumber"];
                    user.LockoutEnabled = Convert.ToBoolean(collection["Lock"]);
                    if (user.LockoutEnabled == true)
                    {
                        user.LockoutEnd = DateTimeOffset.MaxValue;
                        await _signInManager.RefreshSignInAsync(user);
                    }
                    else
                    {
                        user.LockoutEnd = DateTimeOffset.MinValue;
                    }
                    if (isExistUsername != null && isExistUsername.UserName != user.UserName)
                    {
                        {
                            SetAlert("UserName Was Existed", 2);
                            return RedirectToAction(nameof(Edit));
                        }
                    }
                    if (isExistEmail != null && isExistEmail.Email != user.Email)
                    {
                        {
                            SetAlert("Email Was Existed", 2);
                            return RedirectToAction(nameof(Edit));
                        }
                    }
                    else
                    {
                        var result = await _userManager.UpdateAsync(user);
                        SetAlert("Update User Information Successfully", 1);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                    return View();
                }
            }
        }

        // GET: UserManageController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                SetAlert("Not Found User", 2);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var userDetails = _userManager.Users.Where(x => x.Id == id)
                      .Select(x => new UserManageViewModel
                      {
                          UserName = x.UserName,
                          Email = x.Email,
                          FirstName = x.FirstName,
                          LastName = x.LastName,
                          Dob = x.Dob,
                          Lockout = x.LockoutEnabled
                      }).FirstOrDefault();
                return View(userDetails);
            }
        }

        // POST: UserManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(string id, IFormCollection collection)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var isAdmin = await _userManager.IsInRoleAsync(user, "Administrator");
                //var current = _userManager.GetUserIdAsync();

                if (isAdmin)
                {
                    SetAlert(String.Format("Cannot Delete User | {0} is Administrator", user.UserName), 3);
                    return RedirectToAction(nameof(Index));
                }
                //if (user.Id == id)
                //{
                //    SetAlert(String.Format("Cannot Delete YourSelf | {0}", user.UserName), 3);
                //    return RedirectToAction(nameof(Index));

                //}
                if (user == null)
                {
                    SetAlert("Not Found User", 3);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    SetAlert("Delete Successfully", 1);
                    await _userManager.DeleteAsync(user);
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
