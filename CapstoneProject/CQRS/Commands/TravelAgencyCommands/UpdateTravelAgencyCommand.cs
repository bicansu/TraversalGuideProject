using Microsoft.AspNetCore.Http;

namespace CapstoneProject.CQRS.Commands.TravelAgencyCommands
{
    public class UpdateTravelAgencyCommand
    {
        public int id { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }
    }
}

