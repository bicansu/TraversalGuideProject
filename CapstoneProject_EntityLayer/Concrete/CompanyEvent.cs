using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class CompanyEvent
    {
        [Key]
        public int CompanyEventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string EventColor { get; set; }
        public DateTime Date { get; set; }
        public int EventTypeID { get; set; }
        public EventType EventType { get; set; } 

        public bool Status { get; set; }
    }
}
