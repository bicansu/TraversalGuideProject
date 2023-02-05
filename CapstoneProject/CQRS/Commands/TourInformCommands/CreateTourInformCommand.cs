using MediatR;
using Microsoft.AspNetCore.Http;

namespace CapstoneProject.CQRS.Commands.TourInformCommands
{
    public class CreateTourInformCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; } 
        public string Price { get; set; } 
        public bool Status { get; set; } 
    }
}
