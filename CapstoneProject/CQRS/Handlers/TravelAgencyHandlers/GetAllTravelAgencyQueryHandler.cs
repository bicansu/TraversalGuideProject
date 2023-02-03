using CapstoneProject.CQRS.Results.TravelAgencyResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CapstoneProject.CQRS.Handlers.TravelAgencyHandlers
{
    public class GetAllTravelAgencyQueryHandler
    {
        private readonly Context _context;

        public GetAllTravelAgencyQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllTravelAgencyQueryResult> Handle()
        {
            var values = _context.TravelAgencys.Select(x => new GetAllTravelAgencyQueryResult
            {
                id = x.TravelAgencyID,
                description = x.Description,
                image = x.Image
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
