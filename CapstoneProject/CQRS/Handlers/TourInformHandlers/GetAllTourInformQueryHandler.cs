using CapstoneProject.CQRS.Queries.TourInformQuery;
using CapstoneProject.CQRS.Results.TourInformResults;
using CapstoneProject_DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CapstoneProject.CQRS.Handlers.TourInformHandlers
{
    public class GetAllTourInformQueryHandler :IRequestHandler<GetAllTourInformQuery, List<GetAllTourInformQueryResult>>
    {
        private readonly Context _context;

        public GetAllTourInformQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllTourInformQueryResult>> Handle(GetAllTourInformQuery request, CancellationToken cancellationToken)
        {
            return await _context.TourInforms.Select(x=>new GetAllTourInformQueryResult
            {

                TourInformID= x.TourInformID,
                Title  = x.Title,
                Image = x.Image,
                Image2 = x.Image2,
                Image3 = x.Image3 
            }).AsNoTracking().ToListAsync();
        }
    }
}
