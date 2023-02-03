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
                //    string path = "";
                 
                //        path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Images"));
                //        if (!Directory.Exists(path))
                //        {
                //            Directory.CreateDirectory(path);
                //        }
                //        using (var fileStream = new FileStream(Path.Combine(path, about.Image.FileName), FileMode.Create))
                //        {
                //            await about.Image.CopyToAsync(fileStream);
                //        }
                       
                   
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
