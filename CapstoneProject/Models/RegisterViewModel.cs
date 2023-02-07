using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen adınızı giriniz")]   //Required : Zorunlu alan belirtmek için kullanılıyor.
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresini giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]

		[Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]       //Compare: kıyaslamayı sağlar.
		public string ConfirmPassword { get; set; }
	}
}
