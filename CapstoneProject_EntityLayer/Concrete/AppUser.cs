using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string ImageUrl { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string MailCode { get; set; } 
        public string PhoneNumber { get; set; } 
        public int Age { get; set; } 
        public string Job { get; set; } 
    }
}
//Bu class identity in getirmediği proportyleri tanımlamak içi kullanıyoruz.