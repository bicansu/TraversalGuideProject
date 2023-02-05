using Microsoft.AspNetCore.Http;

namespace CapstoneProject.CQRS.Commands.TravelAgencyCommands
{
    public class CreateTravelAgencyCommand
    {
        public int TravelAgencyID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
