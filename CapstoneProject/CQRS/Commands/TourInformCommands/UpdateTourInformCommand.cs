using MediatR;
using Microsoft.AspNetCore.Http;

namespace CapstoneProject.CQRS.Commands.TourInformCommands
{
    public class UpdateTourInformCommand:IRequest
    {
        public int TourInformID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; } 
        public string Price { get; set; } 
        public bool Status{ get; set; } 
    }
}
