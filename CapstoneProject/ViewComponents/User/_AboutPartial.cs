using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.User
{
    public class _AboutPartial:ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke() //MVC de partiallara direk erişim sağlanabiliyor url üzerinden ama viewcompanetlere direk iletişim sağlanamıyor.
        {
            var values = aboutManager.TGetList();
            var val2   = aboutManager.TGetByID(1);
            ViewBag.ld = val2.LongDescription;
            return View(values);
        }
    }
}
//View Component bizim için yeni bir terimdir. Asp.Net Core ile hayatımıza giriş yapmıştır.
//Partial view'e benzemektedir ve Partial viewden daha iyidir.
//Birden çok  view'de kullanılabilir ve yeniden kullanılabilir birleşen(component) yazmamızı sağlar.
