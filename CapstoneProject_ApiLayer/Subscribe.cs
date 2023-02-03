using System.ComponentModel.DataAnnotations;

namespace CapstoneProject_ApiLayer
{
    public class Subscribe
    {
        [Key]
            public int ID { get; set; }
            public string NameSurname { get; set; }
            public string Email { get; set; }
            public bool Status { get; set; }
       
    }
}
