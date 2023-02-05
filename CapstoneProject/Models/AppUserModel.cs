using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class AppUserModel
    {
        public int Id { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string MailCode { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
    }
}
