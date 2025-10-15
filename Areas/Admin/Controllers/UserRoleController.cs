using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagementMVC.Models;
using StockManagementMVC.Models.ViewModel;
using StockManagementMVC.Repository;
using System;

namespace StockManagementMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dbContext;
        public UserRoleController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            DataContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var model = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserWithRolesViewModel
                {
                    User = user,
                    Roles = roles.ToList()
                });
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserRolesViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,

                Roles = roles.Select(role => new RoleSelection
                {
                    RoleName = role.Name,
                    IsSelected = userRoles.Contains(role.Name)
                }).ToList()
            };

            return View(model);
        }
        // POST: Gán quyền
        [HttpPost]
        public async Task<IActionResult> Manage(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId); //A
            var userRoles = await _userManager.GetRolesAsync(user); //A - Admin

            var selectedRoles = model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName).ToList(); //Admin //f8a03ec5-c2be-4ff8-80ae-7f1f4782cf02

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles)); //A - Nhânvien

            TempData["Message"] = "Cập nhật quyền thành công.";
            return RedirectToAction("Index");
        }

    }
}
