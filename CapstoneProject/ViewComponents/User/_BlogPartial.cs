using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
	public class _BlogPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
