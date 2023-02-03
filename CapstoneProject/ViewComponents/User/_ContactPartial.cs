using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _ContactPartial : ViewComponent
    {
        Contact3Manager _contactManager = new Contact3Manager(new EfContact3Dal());

        
        public IViewComponentResult Invoke()
        {
            return View();
        }

        
    }
}
