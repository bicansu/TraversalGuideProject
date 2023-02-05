using System.Collections.Generic;

namespace CapstoneProject_ApiLayer.Models
{
    public class Occupation
    {
        public Occupation() 
        { 
            Users = new List<User>();
        }
        public int OccupationID { get; set; }
        public string OccupationName { get; set; }
        public List<User> Users{ get; set; }
    }
}
