using CapstoneProject.CQRS.Results.TourInformResults;
using MediatR;
using System.Collections.Generic;

namespace CapstoneProject.CQRS.Queries.TourInformQuery
{
    public class GetAllTourInformQuery : IRequest<List<GetAllTourInformQueryResult>> // Köprü olaca
    {

    }
}
