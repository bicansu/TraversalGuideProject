using CapstoneProject.Models;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Rename;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCalendarController : Controller
    {
        private readonly ICompanyEventService _companyEventService;
        private readonly IEventTypeService _eventTypeService;

        public AdminCalendarController(ICompanyEventService companyEventService, IEventTypeService eventTypeService)
        {
            _companyEventService = companyEventService;
            _eventTypeService = eventTypeService;
        }

        public IActionResult Index()
        {
            Context c = new Context();
            ViewData["EtkinlikTipleri"] = c.EventTypes.ToList();
            return View();
        }
        
        public IActionResult EtkinlikEkle(int val)
        {
            Context c = new Context();
            var values = c.EventTypes.Where(x => x.EventTypeID == val).FirstOrDefault();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
           
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(AdminEventModel p)
        {
            CompanyEvent c = new CompanyEvent();
            c.Title = p.Title;
            c.Adress = p.Adress;
            c.Description = p.Description;
            c.PhoneNumber = p.PhoneNumber;
            c.EventTypeID = p.EventTypeID;
            c.EventColor = p.EventColor;
            var zaman = p.Day + " " + p.Hour;
            c.Date = DateTime.Parse(zaman);
            c.Status = true;

            _companyEventService.TAdd(c);

            //Tüm kullanıcılara mail gönder 
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44313/api/Subsc");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var aboneList = JsonConvert.DeserializeObject<List<SubClass>>(jsonString);

            foreach (var rs in aboneList)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddress = new MailboxAddress("Admin", "cnssrc11@gmail.com");
                mimeMessage.From.Add(mailboxAddress);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", rs.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = p.Description + "\n Etkinlik Tarihi: " + DateTime.Parse(zaman) + " İrtibat Numarası: " + p.PhoneNumber;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                //mimeMessage.Body = mailRequest.Body
                mimeMessage.Subject = "Etkinlik Bildirimi - " + p.Title;

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("cnssrc11@gmail.com", "iocezmifqhnozczc");
                client.Send(mimeMessage);
                client.Disconnect(true);

                ViewBag.sonucBasarili = "İşlem Başarı İle Gerçekleştirilmiştir.";
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AllCalendarVal()
        {
            Context c = new Context();
            var values = c.CompanyEvents.ToList();
          

            var list = new List<CalendarModel>();
            CalendarModel[] ar = new CalendarModel[values.Count];
            foreach (var x in values)
            {
                int eventid;
                var eventname = "";
                var values2 = c.EventTypes.Where(y => y.EventTypeID == x.EventTypeID).FirstOrDefault();

                eventid = values2.EventTypeID;
                eventname= values2.Name;
                 
                string[] dizi = x.Date.ToString().Split(' ');
                string[] dizi2 = dizi[0].ToString().Split('.');
                var saatdizi = dizi[1].ToString().Split(':');
                var saat = saatdizi[0] + ":" + saatdizi[1];
                if (Convert.ToInt32(dizi2[0])<10)
                {
                    dizi2[0] = "0"+dizi2[0];
                }
                var yenitarih = dizi2[2] + "-" + dizi2[1] + "-" + dizi2[0];
                list.Add(new CalendarModel {
                    id=x.CompanyEventID,
                    vid = x.CompanyEventID,
                    title= saat + " "+x.Title+"("+eventname+")" ,
                    backgroundColor=x.EventColor,
                    eventID = eventid,
                    eventname = eventname,
                    start = yenitarih, 
                });
            }
           
            var jsonValues = JsonConvert.SerializeObject(list);
            return Json(jsonValues);

        }
        public IActionResult GetSpecEvent(int CompanyEventID)
        {
            Context c = new Context();
            var values = c.CompanyEvents.Where(x => x.CompanyEventID == CompanyEventID).FirstOrDefault();


            var list = new List<CalendarModel>();
            CalendarModel[] ar = new CalendarModel[1];

            string[] dizi = values.Date.ToString().Split(' ');
            string[] dizi2 = dizi[0].ToString().Split('.');
            var saatdizi = dizi[1].ToString().Split(':');
            var saat = saatdizi[0] + ":" + saatdizi[1];
            if (Convert.ToInt32(dizi2[0]) < 10)
            {
                dizi2[0] = "0" + dizi2[0];
            }
            var yenitarih = dizi2[2] + "-" + dizi2[1] + "-" + dizi2[0]; 
            var title2 = "";
            int eventid;
            var eventname = "";
            var values2 = c.EventTypes.Where(y => y.EventTypeID == values.EventTypeID).FirstOrDefault();

            eventid = values2.EventTypeID;
            eventname = values2.Name;
            title2 = values.Title; 

            list.Add(new CalendarModel { 
                id = values.CompanyEventID,
                vid = values.CompanyEventID,
                title = saat + " " + values.Title,
                backgroundColor = "",
                phonenumber = values.PhoneNumber,
                description = values.Description,
                day = yenitarih,
                hour = saat,
                adress = values.Adress,
                eventID = eventid,
                eventname = eventname,
                title2 = title2,
                start = yenitarih });
             
            var jsonValues = JsonConvert.SerializeObject(list);

            return Json(jsonValues);

        }
        [HttpPost]
        public async Task<IActionResult> EditEvent(AdminEventModel p)
        {
          
            CompanyEvent c = new CompanyEvent();
            c.Title = p.Title;
            c.CompanyEventID = p.CompanyEventID;
            c.PhoneNumber= p.PhoneNumber;
            c.Adress= p.Adress;
            c.Description = p.Description; 
            c.EventTypeID = p.EventTypeID; 
            c.Date = DateTime.Parse(p.Day.ToString() + " " + p.Hour); ;
            c.Status = true;

            _companyEventService.TUpdate(c);

            //Tüm kullanıcılara mail gönder 
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44313/api/Subsc");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var aboneList = JsonConvert.DeserializeObject<List<SubClass>>(jsonString);

            foreach (var rs in aboneList)
            {

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddress = new MailboxAddress("Admin", "cnssrc11@gmail.com");
                mimeMessage.From.Add(mailboxAddress);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", rs.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = p.Description + "\n Etkinlik Tarihi: " + DateTime.Parse(p.Day.ToString() + " " + p.Hour) + " İrtibat Numarası: " + p.PhoneNumber + " olarak güncellenmiştir.";
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                //mimeMessage.Body = mailRequest.Body
                mimeMessage.Subject = "(DÜZELTME)Etkinlik Bildirimi - " + p.Title;

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("cnssrc11@gmail.com", "iocezmifqhnozczc");
                client.Send(mimeMessage);

                client.Disconnect(true);

                ViewBag.sonucBasarili = "İşlem Başarı İle Gerçekleştirilmiştir.";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddEventType(AdminEventModel p)
        {
            EventType b = new EventType();
            //string[] renkdizi = p.EventColor.Split("-");
            b.EventColor = p.EventColor;
            b.Name = p.Name; 
            _eventTypeService.TAdd(b);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCompanyEvent(int CompanyEventID)
        {
            var values = _companyEventService.TGetByID(CompanyEventID);
            _companyEventService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeEventDate(int CompanyEventID, string Date)
        {
          
            Context c = new Context();
            var values = c.CompanyEvents.Find(CompanyEventID);
            string[] dizi = values.Date.ToString().Split(' ');
            string[] dizi2 = dizi[0].ToString().Split('.');
            var saatdizi = dizi[1].ToString().Split(':');
            var saat = saatdizi[0] + ":" + saatdizi[1];
            var tarih = dizi2[2] + "-" + dizi2[1] + "-" + dizi2[0];
            values.Date = DateTime.Parse(Date+" "+saat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
