using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
