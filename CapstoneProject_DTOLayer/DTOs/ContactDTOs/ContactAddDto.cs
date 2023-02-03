using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOLayer.DTOs.ContactDTOs
{
    //Validasyonlar ile Propertyleri birbirinden ayırmak için DTO katmanını kuruyoruz.
    public class ContactAddDto
    {  
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
    }
}
//Auto mapper: Buraya tanımlanan extensionların otomatik olarak maplenmesi için kullanılan kütüphanedir.