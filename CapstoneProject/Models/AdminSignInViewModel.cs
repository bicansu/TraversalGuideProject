using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class AdminSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullaıcı adını giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }
    }
}
