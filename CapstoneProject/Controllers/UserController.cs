using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IContact3Service _contact2Service;
        private readonly ISubscriberService _subscriberService;

        public UserController(IContact3Service contact2Service, ISubscriberService subscriberService)
        {
            _contact2Service = contact2Service;
            _subscriberService = subscriberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact3 contact3)
        {
            _contact2Service.TAdd(contact3);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult AddSub(Subscriber p)
        {
            _subscriberService.TAdd(p);
            p.Status = true;
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(UserSubClass p)
        {

            var httpClient = new HttpClient();
            var jsonSubscribe = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonSubscribe, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44313/api/Subsc", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }


    }

    public class UserSubClass
    {

        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
