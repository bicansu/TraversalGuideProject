using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;

namespace CapstoneProject.CQRS.Handlers.TravelAgencyHandlers
{
    public class RemoveTravelAgencyCommandHandler
    {
        private readonly Context _context;

        public RemoveTravelAgencyCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveTravelAgencyCommand command)
        {
            var values = _context.TravelAgencys.Find(command.Id);
            _context.TravelAgencys.Remove(values);
            _context.SaveChanges();
        }
    }
}
