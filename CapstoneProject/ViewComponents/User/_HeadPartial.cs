using CapstoneProject_BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _HeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
