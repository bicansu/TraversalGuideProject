using System;

namespace CapstoneProject.Models
{
    public class AdminEventModel
    {
        public int CompanyEventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Day { get; set; }  
        public string Hour { get; set; }  
        public string EventColor { get; set; }  
        public string Name { get; set; }  
        public int EventTypeID { get; set; }  
        public bool Status { get; set; }
    }
}
