using CapstoneProject_ApiLayer.DataAccessLayer;
using CapstoneProject_ApiLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject_ApiLayer.Hubs
{
    //IEnumerable, generic olamayan bir koleksiyon üzerinde iterasyon(liste içerisinde dönmemizi) yapmamızı sağlar. (memory üzerinde işlem yaparken kullanılır)
    //IQueryable, belli bir uzak veri kaynağından(web service,database…) verileri sorgulamak için işlevsellik sağlar. (veritabından sorgu oluşturarak)
    public class ElectricHub:Hub
    {
        private readonly ElectricService _service; 

        public ElectricHub(ElectricService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetElectricList")]
        public async Task GetElectricList()
        {
            await Clients.All.SendAsync("ReceiveElectricList", _service.GetElectricChartList());
        }

       
    }
}
