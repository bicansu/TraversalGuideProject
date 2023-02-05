using CapstoneProject.CQRS.Commands.TourInformCommands;
using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using MediatR;
using System.IO;
using System;
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

            values.Description = request.Description;
            values.Title = request.Title;
            values.Image = imageName; 
            values.Price = request.Price; 
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
