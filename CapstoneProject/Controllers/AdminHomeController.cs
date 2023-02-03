using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class AdminHomeController : Controller
    {
        

        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.KullaniciSayisi = c.Accounts.Count();
            ViewBag.AboneSayisi     = c.Subscribers.Count();

            return View();
        }
    }
}
