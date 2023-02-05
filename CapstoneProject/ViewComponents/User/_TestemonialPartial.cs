using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
	public class _TestemonialPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
