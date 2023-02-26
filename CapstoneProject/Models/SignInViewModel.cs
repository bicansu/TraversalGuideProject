using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")] 
        public string email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }
    }
}
