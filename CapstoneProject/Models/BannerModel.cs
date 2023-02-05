using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class BannerModel
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public bool Status { get; set; }
    }
}
