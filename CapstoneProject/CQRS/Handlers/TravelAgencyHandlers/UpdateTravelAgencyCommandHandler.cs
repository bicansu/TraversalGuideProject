using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_DataAccessLayer.Concrete;
using System.IO;
using System;

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


            string imageName = "";
            if (command.image != null)
            {
                var extension = Path.GetExtension(command.image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                command.image.CopyTo(stream);
                imageName = "/Images/" + newimagename;
            }
            else
            {
                imageName = "";
            }
            values.Description = command.description;
            values.Title = command.title;
            values.Image = imageName;
            _context.SaveChanges();
        }
    }
}
