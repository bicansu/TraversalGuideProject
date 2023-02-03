using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AdminBannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
