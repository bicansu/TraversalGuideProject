using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class EventType
    {
        [Key]
        public int EventTypeID { get; set; }
        public string Name { get; set; }
        public string EventColor { get; set; }
        public List<CompanyEvent> CompanyEvents { get; set; }
    }
}
