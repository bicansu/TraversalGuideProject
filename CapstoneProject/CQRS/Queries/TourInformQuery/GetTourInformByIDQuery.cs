using CapstoneProject.CQRS.Results.TourInformResults;
using MediatR;

namespace CapstoneProject.CQRS.Queries.TourInformQuery
{
    public class GetTourInformByIDQuery : IRequest<GetTourInformByIDQueryResult>
    {
        public GetTourInformByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
