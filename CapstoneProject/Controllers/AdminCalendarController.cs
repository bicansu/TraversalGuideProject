using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AdminCalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
