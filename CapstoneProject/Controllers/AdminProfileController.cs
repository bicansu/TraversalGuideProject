using CapstoneProject.Models;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var values = c.Users.Where(x => x.UserName == username).FirstOrDefault();
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;
            ViewBag.ImageUrl = values.ImageUrl;
            ViewBag.UserName = values.UserName;
            ViewBag.PhoneNumber = values.PhoneNumber;
            ViewBag.Gender = values.Gender;
            ViewBag.Job = values.Job;
            if(values.Age == 0)
            {
                ViewBag.Age = "";

            }
            else {
                ViewBag.Age = values.Age;
            }
            
            ViewBag.Id =values.Id;
 
            List<SelectListItem> gender = new()
            {
                new SelectListItem { Value = "", Text = "Seçiniz" },
                new SelectListItem { Value = "Erkek", Text = "Erkek" },
                new SelectListItem { Value = "Kadın", Text = "Kadın" } 
            };

            //assigning SelectListItem to view Bag
            ViewBag.genderList = gender;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserModel appUser)
        {
            AppUser au = new AppUser();

            var user = await _userManager.FindByIdAsync(appUser.Id.ToString());
            user.Name=appUser.Name;
            user.Surname=appUser.Surname;
            user.PhoneNumber=appUser.PhoneNumber;
            user.Gender=appUser.Gender;
            user.Age = appUser.Age;
            user.Job = appUser.Job;
          

            if (appUser.ImageUrl != null)
            {
                var extension = Path.GetExtension(appUser.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                appUser.ImageUrl.CopyTo(stream);
                au.ImageUrl= newimagename;
                user.ImageUrl = "/Images/" + newimagename;
            }
           var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                ViewBag.State = true;
            }
            else
            {
                ViewBag.State = false;
            }
            return RedirectToAction();
        }
    }
}
