using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _GalleryPartial:ViewComponent
    {
       
        public IViewComponentResult Invoke()  
        { 
            return View();
        }
    }
}
 
