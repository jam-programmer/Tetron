using Framework.CQRS.Query.Introduction;
using Framework.Factories.Placement;
using MediatR;

namespace Framework.CQRS.Query.Placement
{
    public class GetPlacementWithFilterQuery:IRequest<List<Placement>>
    {
        public Filter Filter { set; get; }
    }

    public class GetPlacementWithFilterQueryHandler : IRequestHandler<GetPlacementWithFilterQuery, List<Placement>>
    {
        private readonly IPlacementFactory _placementFactory;

        public GetPlacementWithFilterQueryHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<List<Placement>> Handle(GetPlacementWithFilterQuery request, CancellationToken cancellationToken)
        {
            return await _placementFactory.GetPlacementsWithFilter(request);
        }
    }
    public class Placement
    {
        public string? PlacementImage { set; get; }
        public Guid? Id { set; get; }
        public string? UserFullName { set; get; }
        public string? PlacementFullName { set; get; }
        public string? PlacementNumber { set; get; }
    }
}
