using CapstoneProject.Models;
using CapstoneProject_DTOLayer.DTOs.AdminDto;
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
		[HttpPost]
		public async Task<IActionResult> Index(SignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				var usr = _userManager.Users.FirstOrDefault(x=> x.Email == p.email);
				if (usr.UserName != "")
				{
					var result = await _signInManager.PasswordSignInAsync(usr.UserName, p.password, false, true);
					ViewBag.sonuc = result;
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
							return RedirectToAction("Index", "Login");
						}

					}
					else
					{
						ModelState.AddModelError("email", "Geçersiz email adresi");
					}
				}
				else
				{
					ModelState.AddModelError("email", "Email adresi bulunamadı.");
				}
			}
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
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
		public void SendEmail(string emailadres, string emailcode)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("CNSTOUR", "cnssrc11@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", emailadres);
			mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = emailcode;
			mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

			mimeMessage.Subject = "Üyelik Kaydı"; //Gönderilecek mailin başlığı

			SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
			smtp.Connect("smtp.gmail.com", 587, false);
			smtp.Authenticate("cnssrc11@gmail.com", "iocezmifqhnozczc");
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

						var user = _userManager.Users.FirstOrDefault(x => x.Id == appUser.Id);
						await _userManager.AddToRoleAsync(user, "Member");

						SendEmail(p.Mail, appUser.MailCode);
						 
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
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }
		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
		{
			var user = await _userManager.FindByEmailAsync(dto.Email);

			if (user != null)
			{
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);

				var passwordResetLink = Url.Action("ResetPassword", "Login", new { email = dto.Email, token = token }, Request.Scheme);

				return RedirectToAction("ForgotPasswordConfirmation", new { url = passwordResetLink, email = dto.Email });
			}
			return View();
		}
		public IActionResult ResetPassword(string email, string token)
		{
			if (email == null && token == null)
			{
				ModelState.AddModelError("All", "Geçersiz İşlem");
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
		{


			var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
			if (user != null)
			{
				var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("All", error.Description);
				}
			}

			return View();
		}


		public IActionResult ForgotPasswordConfirmation(string url, string email)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "cnssrc11@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);
			mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = "Şifrenizi line tıklayarak güncelleyebilirsiniz.";
			bodyBuilder.TextBody += url;
			mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

			mimeMessage.Subject = "Şifre Sıfırlama"; //Gönderilecek mailin başlığı


			SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
			smtp.Connect("smtp.gmail.com", 587, false);
			smtp.Authenticate("cnssrc11@gmail.com", "iocezmifqhnozczc");
			smtp.Send(mimeMessage);
			smtp.Disconnect(true);

			return RedirectToAction("Index", "Login");
		}
	}
}
