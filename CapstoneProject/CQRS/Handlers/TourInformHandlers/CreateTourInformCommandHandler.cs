using CapstoneProject.CQRS.Commands.TourInformCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using MediatR;
using System.IO;
using System;
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
            string imageName = "";
            if (request.Image != null)
            {
                var extension = Path.GetExtension(request.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                request.Image.CopyTo(stream);
                imageName = "/Images/" + newimagename;
            }
            else
            {
                imageName = "";
            }
            _context.TourInforms.Add(new TourInform
            {
                Title = request.Title,
                Description = request.Description,
                Image = imageName,
                Price = request.Price, 
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value; 
        }
    }
}
