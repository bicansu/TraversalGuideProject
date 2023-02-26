using CapstoneProject_BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOurInfoController : Controller
    {
        private readonly IOurInfoService _ourInfoService;

		public AdminOurInfoController(IOurInfoService ourInfoService)
		{
			_ourInfoService = ourInfoService;
		}

		public IActionResult Index()
		{
			var values = _ourInfoService.TGetList();
			return View(values);
		}
    }
}
