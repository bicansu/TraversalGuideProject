using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.ViewComponents.User
{
    public class _NavHeaderPartial : ViewComponent
    {
        BannerManager bannerManager= new BannerManager(new EfBannerDal());   
        public IViewComponentResult Invoke()
        {
            //Context c = new Context();
            var values = bannerManager.TGetList();
            //var values = c.Banners.Where(x => x.BannerID == 1).FirstOrDefault();

            return View(values);
        }
    }
}
