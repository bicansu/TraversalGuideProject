using CapstoneProject.CQRS.Commands.TourInformCommands;
using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CapstoneProject.CQRS.Handlers.TourInformHandlers
{
    public class UpdateTourInformCommandHandler:IRequestHandler<UpdateTourInformCommand>
    {
        private readonly Context _context;

        public UpdateTourInformCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTourInformCommand request, CancellationToken cancellationToken)
        {
            var values = _context.TourInforms.Find(request.TourInformID);
            values.Description = request.Description;
            values.Title = request.Title;
            values.Image = request.Image;
            values.Image2 = request.Image2;
            values.Image3 = request.Image3;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
