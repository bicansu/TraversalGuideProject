using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class ImageUpload
    {
        public IFormFile Image{ get; set; }
    }
}
