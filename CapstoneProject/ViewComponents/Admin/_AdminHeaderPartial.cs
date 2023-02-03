using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.ViewComponents.Admin
{
    public class _AdminHeaderPartial : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var values = c.Users.Where(x => x.UserName == username).FirstOrDefault();
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;  
            ViewBag.ImageUrl = values.ImageUrl;  
            return View();
        }
    }
}
