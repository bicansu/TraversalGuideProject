using MediatR;

namespace CapstoneProject.CQRS.Commands.TourInformCommands
{
    public class UpdateTourInformCommand:IRequest
    {
        public int TourInformID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }
}
