using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _FooterPartial :ViewComponent
    {
        OurInfoManager ourInfoManager = new OurInfoManager(new EfOurInfoDal());
        public IViewComponentResult Invoke()
        {
            var values = ourInfoManager.TGetByID(1);
            ViewBag.address = values.Address;
            ViewBag.phone   = values.Phone;
            ViewBag.email   = values.Email;
            return View();
        }
    }
}
