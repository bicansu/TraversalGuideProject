using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.ViewComponents.User
{
    public class _HeaderPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

		public _HeaderPartial(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public  IViewComponentResult Invoke()
        {
			
			if (User.Identity.Name != null && User.Identity.Name.Any())
			{
				var username = User.Identity.Name;
				var values = _userManager.Users.Where(x => x.UserName == username).FirstOrDefault();
		
				ViewBag.Name = values.Name;
				ViewBag.Surname = values.Surname;
				ViewBag.ImageUrl = values.ImageUrl;
				ViewBag.Job = values.Job;
				ViewBag.Age = values.Age;
			}
			else
			{
				ViewBag.Name = "";
				ViewBag.Surname = "";
				ViewBag.ImageUrl = "";
				ViewBag.Job = "";
				ViewBag.Age = "";
			}
			return View();
        }
    }
}
