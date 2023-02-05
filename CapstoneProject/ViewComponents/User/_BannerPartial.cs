 
using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.ViewComponents.User
{
	public class _BannerPartial:ViewComponent
	{
		BannerManager bannerManager = new BannerManager(new EfBannerDal());

		public IViewComponentResult Invoke()
		{ 
			 
			Context c = new Context();
			var values = c.Banners.Where(x => x.Status == true).ToList();
			 foreach(var item in values)
			{
				ViewBag.Image = item.Image;
				ViewBag.Title = item.Title;
				break;
			}
			return View(values);
		}
	}
}
