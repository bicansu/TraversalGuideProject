using CapstoneProject_DTOLayer.DTOs.AdminDto;
using CapstoneProject_EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
	[AllowAnonymous]
	public class AdminForgotPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminForgotPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(ForgotPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var passwordResetLink = Url.Action("ResetPassword", "AdminForgotPassword", new { email = dto.Email, token = token }, Request.Scheme);

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
                    return RedirectToAction("SignIn", "AdminLogin");
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

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "cnsrc11@gmail.com");
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
            smtp.Authenticate("cnsrc11@gmail.com", "rvjtklrwwmwfhlin");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);

            return RedirectToAction("SignIn", "AdminLogin");
        }
    }
}
