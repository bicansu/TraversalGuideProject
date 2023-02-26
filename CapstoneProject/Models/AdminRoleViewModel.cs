using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class AdminRoleViewModel
    { 
        [Required(ErrorMessage ="Lütfen rol adını boş bırakmayınız.")]
        public string RoleName{ get; set; }
    }
}
