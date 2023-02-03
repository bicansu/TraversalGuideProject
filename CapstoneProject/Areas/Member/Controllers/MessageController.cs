using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
