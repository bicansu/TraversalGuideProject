
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class AdminUsers : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUsers(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Context c = new Context();
           var values = c.Users.ToList();
            return View(values);
        }
      

		 
	}
}
