using MediatR;

namespace CapstoneProject.CQRS.Commands.TourInformCommands
{
    public class RemoveTourInformCommand:IRequest
    {
        public RemoveTourInformCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
