using Microsoft.AspNetCore.Http;

namespace CapstoneProject.Models
{
    public class AdminTravelAgencyModel
    {
		public int TravelAgencyID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
	}
}
