using CapstoneProject.Models;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        private readonly IMailRequestService _mailRequestService;

        public MailController(IMailRequestService mailRequestService)
        {
            _mailRequestService = mailRequestService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.sonucBasarili = "";
            return View();
        }

        [HttpPost]

        public IActionResult Index(MailRequestModel mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "cnssrc11@gmail.com");

            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //mimeMessage.Body = mailRequest.Body
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("cnssrc11@gmail.com", "iocezmifqhnozczc");
            client.Send(mimeMessage);

            MailRequest c = new MailRequest();
            c.Subject= mailRequest.Subject;
            c.Body = mailRequest.Body;
            c.SenderMail    = mailRequest.SenderMail;
            c.ReceiverMail = mailRequest.ReceiverMail;
            c.Name = mailRequest.Name;

            _mailRequestService.TAdd(c);
            client.Disconnect(true);
            
            ViewBag.sonucBasarili = "İşlem Başarı İle Gerçekleştirilmiştir.";
            return View();
        }

    }
}
