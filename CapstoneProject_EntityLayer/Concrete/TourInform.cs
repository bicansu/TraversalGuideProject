using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class TourInform
    {
        public int TourInformID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; } 
        public bool Status { get; set; }
    }
}
