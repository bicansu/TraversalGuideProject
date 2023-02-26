using CapstoneProject.Models;
using CapstoneProject_EntityLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AdminRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=> x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleUsers(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var kullanicilar = _userManager.Users.ToList();
            List<RoleUsersViewModel> model = new List<RoleUsersViewModel>();
            foreach (var item in kullanicilar)
            {
                var user = _userManager.Users.FirstOrDefault(x=> x.Id == item.Id);
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.Contains(values.Name)) {
                    RoleUsersViewModel m = new RoleUsersViewModel();
                    m.UserId = user.Id;
                    m.RoleId = id;
                    m.RoleName = values.Name;
                    m.UserName = user.UserName;
                    m.Surname= user.Surname;
                    m.Name = user.Name;
                    model.Add(m);
                }
            }
            TempData["RoleId"] = id;
            return View(model);
        }
        
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var roleid = (int)TempData["RoleId"]; 
            var user = _userManager.Users.FirstOrDefault(x=>x.Id == id);
            var role = _roleManager.Roles.FirstOrDefault(y => y.Id == roleid);
            await _userManager.RemoveFromRoleAsync(user, role.Name);
             
            return RedirectToAction("GetRoleUsers","AdminRole", new { id = roleid });
        }
    }
}
