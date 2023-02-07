using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
