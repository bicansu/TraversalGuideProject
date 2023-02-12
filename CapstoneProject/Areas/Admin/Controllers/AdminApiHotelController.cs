using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using CapstoneProject.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminApiHotelController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?units=metric&checkin_date=2023-02-25&dest_type=city&dest_id=-1456928&checkout_date=2023-05-25&order_by=popularity&filter_by_currency=EUR&locale=en-gb&adults_number=2&room_number=1&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_number=2&children_ages=5%2C0&page_number=0"),
                Headers =
    {
        { "X-RapidAPI-Key", "880b266bc8mshedea4f3989e0f54p14a664jsn262ff0c72718" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiHotelViewModel2>(body);
                return View(values.results);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApiHotelViewModel p)
        {
            if(DateTime.Parse(p.checkinDate)>=DateTime.Now || DateTime.Parse(p.checkoutDate)>=DateTime.Now)
            {

           
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?units=metric&checkin_date="+p.checkinDate+"&dest_type=city&dest_id=-1456928&checkout_date="+p.checkoutDate+"&order_by=popularity&filter_by_currency=EUR&locale=en-gb&adults_number="+p.adults_number+"&room_number=1&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_number=2&children_ages=5%2C0&page_number=0"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "880b266bc8mshedea4f3989e0f54p14a664jsn262ff0c72718" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ApiHotelViewModel2>(body);
                    return View(values.results);

                }
            }
            return View();

        }
    }
}