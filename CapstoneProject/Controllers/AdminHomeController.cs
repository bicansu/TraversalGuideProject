using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        

        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.KullaniciSayisi = c.UserCounts.Count();
            ViewBag.AboneSayisi     = c.Subscribers.Count();
            ViewBag.HesapSayisi     = c.Accounts.Count();

            return View();
        }
    }
}
