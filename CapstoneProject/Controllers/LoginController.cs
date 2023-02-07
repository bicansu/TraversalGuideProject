using CapstoneProject.Models;
using CapstoneProject_EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager; //Değiştrilemesi diye readonly yazıyoruz. Private da bu sayfaya özel olmasını sağlıyor.
		private readonly SignInManager<AppUser> _signInManager;

		private readonly RoleManager<AppRole> _roleManager;


		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpGet]
		public IActionResult EmailConfirmed()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> EmailConfirmedSave(AppUser appUser)
		{
			var user = await _userManager.FindByEmailAsync(appUser.Email);
			if (user.MailCode == appUser.MailCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
		public void SendEmail(string emailadres, string emailcode)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "cnsrc11@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", emailadres);
			mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = emailcode;
			mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

			mimeMessage.Subject = "Üyelik Kaydı"; //Gönderilecek mailin başlığı

			SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
			smtp.Connect("smtp.gmail.com", 587, false);
			smtp.Authenticate("cnsrc11@gmail.com", "rvjtklrwwmwfhlin");
			smtp.Send(mimeMessage);
			smtp.Disconnect(true);
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel p)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					Name = p.Name,
					Surname = p.Surname,
					Email = p.Mail,
					UserName = p.Username,
					MailCode = new Random().Next(100000, 999999).ToString()

				};
				if (p.Password == p.ConfirmPassword)
				{
					var result = await _userManager.CreateAsync(appUser, p.Password);

					if (result.Succeeded)
					{
						
						//await _userManager.AddToRoleAsync(appUser, 2);

						
						
						SendEmail(p.Mail, appUser.MailCode);

						//return RedirectToAction("SignIn");
						return RedirectToAction("EmailConfirmed", "Login");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description);
						}

					}

				}
				else
				{
					ModelState.AddModelError("", "Şifreler birbiriyle uyuşmuyor.");
				}

			}
			return View();
		}

		[HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.email, p.password, false, true);
                if (result.Succeeded)
                {
                    var user = _userManager.Users.FirstOrDefault(x => x.Email == p.email);
                    var role = await _userManager.GetRolesAsync(user);
                    if (role.Contains("Member"))
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("SignIn", "Login");
                    }

                }
                else
                {
                    ModelState.AddModelError("username", "Geçersiz kullanıcı adı.");

                }
            }
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }

    }
}
