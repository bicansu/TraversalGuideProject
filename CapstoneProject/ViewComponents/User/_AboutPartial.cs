using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
	public class _AboutPartial:ViewComponent
	{
		AboutManager aboutManager = new AboutManager(new EfAboutDal());
		public IViewComponentResult Invoke() //MVC de partiallara direk erişim sağlanabiliyor url üzerinden ama viewcompanetlere direk iletişim sağlanamıyor.
		{
			var values = aboutManager.TGetStatTrue();
			return View(values);
		}
	}
}
