using FluentValidation.Results;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using CapstoneProject_ApiLayer.Models;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapstoneProject.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAboutAsync(About about)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult result = validationRules.Validate(about);

            if (result.IsValid)
            {

                //if (about.Image != null)
                //{
                //    var extension = Path.GetExtension(appUser.ImageUrl.FileName);
                //    var newimagename = Guid.NewGuid() + extension;
                //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                //    var stream = new FileStream(location, FileMode.Create);
                //    appUser.ImageUrl.CopyTo(stream);
                //    au.ImageUrl = newimagename;
                //    user.ImageUrl = "/Images/" + newimagename;
                //}

                _aboutService.TAdd(about);
                return RedirectToAction("Index");
            }
            else{
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About p)
        {
           
            _aboutService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return RedirectToAction("Index");
        }

    }
}
