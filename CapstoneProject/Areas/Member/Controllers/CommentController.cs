using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
