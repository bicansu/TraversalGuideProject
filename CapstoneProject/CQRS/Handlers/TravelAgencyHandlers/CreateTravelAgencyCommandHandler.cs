using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject_ApiLayer.Models;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using System.IO;
using System;

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
            string imageName = "";
            if (command.Image != null)
            {
                var extension = Path.GetExtension(command.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                command.Image.CopyTo(stream); 
                imageName = "/Images/" + newimagename;
            }
            else
            {
                imageName = "";
            }

            _context.TravelAgencys.Add(new TravelAgency
                { 
                TravelAgencyID = command.TravelAgencyID,
                Description = command.Description,
                Image = imageName
            } );
            _context.SaveChanges();
         }
    }
}
