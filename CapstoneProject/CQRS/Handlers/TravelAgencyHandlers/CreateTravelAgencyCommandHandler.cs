using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;

namespace CapstoneProject.CQRS.Handlers.TravelAgencyHandlers
{
    public class CreateTravelAgencyCommandHandler
    {
        private readonly Context _context;

        public CreateTravelAgencyCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreateTravelAgencyCommand command){
            _context.TravelAgencys.Add(new TravelAgency
                {
                TravelAgencyID = command.TravelAgencyID,
                Description = command.Description,
                Image = command.Image
            } );
            _context.SaveChanges();
         }
    }
}
