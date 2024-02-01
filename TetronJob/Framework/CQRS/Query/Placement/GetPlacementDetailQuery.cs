using Framework.Factories.Placement;
using MediatR;

namespace Framework.CQRS.Query.Placement
{
    public class GetPlacementDetailQuery:IRequest<PlacementDetail>
    {
        public Guid Id { get; set; }
    }

    public class GetPlacementDetailQueryHandler : IRequestHandler<GetPlacementDetailQuery, PlacementDetail>
    {
        private readonly IPlacementFactory _placementFactory;

        public GetPlacementDetailQueryHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<PlacementDetail> Handle(GetPlacementDetailQuery request, CancellationToken cancellationToken)
        {
            return await _placementFactory.GetPlacementDetailByIdAsync(request.Id);
        }
    }
    public class PlacementDetail
    {
        public List<string>? Images { set; get; } = new();
        public string? ProvinceName { set; get; }
        public string? CityName { set; get; }
        public string? UserFullName { set; get; }
        public string? PlacementFullName { set; get; }
        public string? PlacementNumber { set; get; }
        public string? PlacementDescription { set; get; }
        public string? PlacementImage { set; get; }
    }
}
