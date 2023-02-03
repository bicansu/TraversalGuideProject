using CapstoneProject.CQRS.Queries.TravelAgencyQuery;
using CapstoneProject.CQRS.Results.TravelAgencyResults;
using CapstoneProject_DataAccessLayer.Concrete;

namespace CapstoneProject.CQRS.Handlers.TravelAgencyHandlers
{
    public class GetTravelAgencyByIDQueryHandler
    {
        private readonly Context _context;

        public GetTravelAgencyByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetTravelAgencyByIDQueryResult Handle(GetTravelAgencyByIDQuery query)
        {
            var values = _context.TravelAgencys.Find(query.id);
            return new GetTravelAgencyByIDQueryResult
            {
                TravelAgencyID = values.TravelAgencyID,
                Description = values.Description,
                Image = values.Image
            };
            

        }
    }
}
