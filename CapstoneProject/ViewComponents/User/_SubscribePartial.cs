using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
	public class _SubscribePartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
