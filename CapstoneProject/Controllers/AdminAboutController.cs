using FluentValidation.Results;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules; 
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using CapstoneProject_ApiLayer.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using CapstoneProject_DataAccessLayer.Concrete;
using System.Linq; 
using CapstoneProject_EntityLayer.Concrete;

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

        public IActionResult ChangeAboutStatFalse(int id)
        {
            Context c = new Context();
            var values = c.Abouts.Find(id);
            values.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeAboutStatTrue(int id)
        {
            Context c = new Context();
            var val2 = c.Abouts.ToList();
            foreach (var item in val2)
            {
                var v = c.Abouts.Find(item.AboutID);
                v.Status = false;
                c.SaveChanges();
            }

            var values = c.Abouts.Find(id);
            values.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
