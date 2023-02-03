using CapstoneProject_ApiLayer.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace CapstoneProject_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscController : Controller
    {
        [HttpGet]
        public IActionResult SubscribeList()
        {
            using var c = new Context();
            var values = c.Subscribes.ToList();
            return Ok(values);   //APİ kodu olduğu için durum kodu belirtmemiz gereklidir.
        }

        [HttpPost]

        public IActionResult SubscribeAdd(Subscribe subscribe)
        {
            using var c = new Context();
            c.Add(subscribe);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult SubscribeGet(int id)
        {
            using var c = new Context();
            var subscribe = c.Subscribes.Find(id);
            if (subscribe == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(subscribe);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult SubscribeDelete(int id)
        {
            using var c = new Context();
            var subscribe = c.Subscribes.Find(id);
            if (subscribe == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(subscribe);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]

        public IActionResult SubscribeUpdate(Subscribe subscribe)
        {
            using var c = new Context();
            var sb = c.Find<Subscribe>(subscribe.ID);
            if (sb == null)
            {
                return NotFound();
            }
            else
            {
                sb.NameSurname = subscribe.NameSurname;
                sb.Email = subscribe.Email;
                sb.Status = subscribe.Status;
                c.Update(sb);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
