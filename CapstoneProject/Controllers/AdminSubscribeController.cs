using CapstoneProject_ApiLayer.DataAccessLayer;
using CapstoneProject_EntityLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSubscribeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44313/api/Subsc");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SubClass>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSubscribe()
        {
            return View();
        }
        [HttpPost]        
        public async Task<IActionResult> AddSubscribe(SubClass p)
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

        [HttpGet]
        public async Task<IActionResult> EditSubscribe(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44313/api/Subsc/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonSubscribe = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SubClass>(jsonSubscribe);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditSubscribe(SubClass p)
        {
            var httpClient = new HttpClient();
            var jsonSubscribe = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonSubscribe, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44313/api/Subsc", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44313/api/Subsc" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ChangeSubStatFalse(int id)
        {
            Context c = new Context();
            var values = c.Subscribes.Find(id);
            values.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeSubStatTrue(int id)
        {
            Context c = new Context();
            var values = c.Subscribes.Find(id);
            values.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    public class SubClass
    {
       
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
