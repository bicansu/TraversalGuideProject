using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _AgencyPartial :ViewComponent
    {
        TourInformManager tourInformManager = new TourInformManager(new EfTourInformDal());
        public IViewComponentResult Invoke()
        {
            var values = tourInformManager.TGetList();
            return View(values);
        }
    }
}
