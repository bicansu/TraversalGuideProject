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
using FluentValidation;

namespace CapstoneProject.Controllers
{
    public class AdminTourInformController : Controller
    {
        private readonly ITourInformaService _tourInformService;

        public AdminTourInformController(ITourInformaService tourInformService)
        {
            _tourInformService = tourInformService;
        }
        public IActionResult Index()
        {
            var values = _tourInformService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTourInform()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTourInform(TourInform tourInform)
        {
            TourInformValidator validationRules = new TourInformValidator();
            ValidationResult result = validationRules.Validate(tourInform);

            if (result.IsValid)
            {

                
                _tourInformService.TAdd(tourInform);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateTourInform(int id)
        {
            var values = _tourInformService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateTourInform(TourInform p)
        {

            _tourInformService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTourInform(int id)
        {
            var values = _tourInformService.TGetByID(id);
            _tourInformService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
