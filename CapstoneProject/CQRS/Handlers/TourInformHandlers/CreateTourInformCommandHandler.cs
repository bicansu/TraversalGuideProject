using CapstoneProject.CQRS.Commands.TourInformCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CapstoneProject.CQRS.Handlers.TourInformHandlers
{
    public class CreateTourInformCommandHandler : IRequestHandler<CreateTourInformCommand>
    {
        private readonly Context _context;

        public CreateTourInformCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTourInformCommand request, CancellationToken cancellationToken)
        {
            _context.TourInforms.Add(new TourInform
            {
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                Image2 = request.Image2,
                Image3 = request.Image3,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value; 
        }
    }
}
