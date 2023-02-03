using CapstoneProject.CQRS.Queries.TourInformQuery;
using CapstoneProject.CQRS.Results.TourInformResults;
using CapstoneProject_DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CapstoneProject.CQRS.Handlers.TourInformHandlers
{
    public class GetTourInformByIDQueryHandler : IRequestHandler<GetTourInformByIDQuery, GetTourInformByIDQueryResult>
    {
        private readonly Context _context;

        public GetTourInformByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetTourInformByIDQueryResult> Handle(GetTourInformByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.TourInforms.FindAsync(request.Id);
            return new GetTourInformByIDQueryResult
            {
                TourInformID = values.TourInformID,
                Title = values.Title,
                Image = values.Image,
                Image2 = values.Image2,
                Image3 = values.Image3
            };
        }
    }
}
