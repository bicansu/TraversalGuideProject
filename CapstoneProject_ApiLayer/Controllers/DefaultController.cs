using CapstoneProject_ApiLayer.DataAccessLayer;
using CapstoneProject_ApiLayer.Hubs;
using CapstoneProject_ApiLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ElectricService _service;

        public DefaultController(ElectricService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("SaveElectric")]
        public async Task<IActionResult> SaveElectric(Electric electric)
        {
            await _service.SaveElectric(electric);
            //IQueryable<Electric> elecricList = _service.GetList();
            return Ok(_service.GetElectricChartList());
        }
        [HttpGet]
        [Route("SendData")]
        public IActionResult SendData()
        {
            Random rnd = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newElectric = new Electric
                    {
                        City = item,
                        Count = rnd.Next(100, 1000),
                        ElectricDate = DateTime.Now.AddDays(x)
                    };
                    _service.SaveElectric(newElectric).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Elektrik verileri veri tabanına kaydedildi");
        }
        [HttpGet]
        [Route("EmployeeList")]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);   //APİ kodu olduğu için durum kodu belirtmemiz gereklidir.
        }

        [HttpPost] 
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee =c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]

        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID);
            if(emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }

    }
}
