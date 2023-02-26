using CapstoneProject.ViewComponents.User;
using CapstoneProject_ApiLayer.Models;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public AdminBannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult Index()
        {
            var values = _bannerService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBanner()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddBanner(BannerModel banner)
        {

            Banner b = new Banner();
            if (banner.Image!= null)
            {
                var extension = Path.GetExtension(banner.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                banner.Image.CopyTo(stream);
                
                b.Image = "/Images/" + newimagename;
            }
             b.Title = banner.Title;
            b.SubTitle = banner.SubTitle;
            b.Description = banner.Description;
            b.Status = banner.Status;
            _bannerService.TAdd(b);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var values = _bannerService.TGetByID(id);
            ViewBag.Image = values.Image;

            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateBanner(BannerModel banner)
        {
            Banner b = new Banner();
            if (banner.Image != null)
            {
                var extension = Path.GetExtension(banner.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                banner.Image.CopyTo(stream);

                b.Image = "/Images/" + newimagename;
            }
            b.BannerID = banner.BannerID;
            b.Title = banner.Title;
            b.SubTitle = banner.SubTitle;
            b.Description = banner.Description;
            b.Status = banner.Status;
            _bannerService.TUpdate(b);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            var values = _bannerService.TGetByID(id);
            _bannerService.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeSubStatFalse(int id)
        {
            Context c = new Context();
            var values = c.Banners.Find(id);
            values.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeSubStatTrue(int id)
        {
            Context c = new Context();
            var val2 = c.Banners.ToList();
            foreach (var item in val2)
            {
                var v = c.Banners.Find(item.BannerID);
                v.Status = false;
                c.SaveChanges();
            }

            var values = c.Banners.Find(id);
            values.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
