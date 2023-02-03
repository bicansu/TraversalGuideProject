using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _ServicePartial :ViewComponent
    {
        TravelAgencyManager agencyManager = new TravelAgencyManager(new EfTravelAgencyDal());
        public IViewComponentResult Invoke()
        {
           
            var values = agencyManager.TGetList();
            var val2 = agencyManager.TGetByID(1);
            ViewBag.ld = val2.Description;
            return View(values);    
        }
    }
}
