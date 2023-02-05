using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class AdminAboutModel
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public IFormFile Image { get; set; }
    }
}
