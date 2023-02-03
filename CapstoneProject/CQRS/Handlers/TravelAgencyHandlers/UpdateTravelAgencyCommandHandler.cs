using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;

namespace CapstoneProject.CQRS.Handlers.TravelAgencyHandlers
{
    public class UpdateTravelAgencyCommandHandler
    {
        private readonly Context _context;

        public UpdateTravelAgencyCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateTravelAgencyCommand command)
        {
            var values = _context.TravelAgencys.Find(command.id);
            values.Description = command.description;
            values.Image = command.image;
            _context.SaveChanges();
        }
    }
}
