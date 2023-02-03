using CapstoneProject.CQRS.Commands.TourInformCommands; 
using CapstoneProject_DataAccessLayer.Concrete;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace CapstoneProject.CQRS.Handlers.TourInformHandlers
{
    public class RemoveTourInformCommandHandler:IRequestHandler<RemoveTourInformCommand>
    {
        private readonly Context _context;

        public RemoveTourInformCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveTourInformCommand request, CancellationToken cancellationToken)
        {
            var values = _context.TourInforms.Find(request.Id); 
            _context.TourInforms.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
