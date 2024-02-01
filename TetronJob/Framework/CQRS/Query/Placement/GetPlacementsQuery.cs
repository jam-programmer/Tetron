using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Placement;
using MediatR;

namespace Framework.CQRS.Query.Placement
{
    public class GetPlacementsQuery:IRequest<PaginatedList<Placement>>
    {
        public PaginatedSearchWithSize Paginated = new PaginatedSearchWithSize();
    }

    public class GetPlacementsQueryHandler : IRequestHandler<GetPlacementsQuery, PaginatedList<Placement>>
    {
        private readonly IPlacementFactory _placementFactory;

        public GetPlacementsQueryHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<PaginatedList<Placement>> Handle(GetPlacementsQuery request, CancellationToken cancellationToken)
        {
            return await _placementFactory.GetPagedSearchWithSizeAsync<Placement>(request.Paginated, cancellationToken);
        }
    }
}
