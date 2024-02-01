using Framework.CQRS.Command.Master.Placement;
using Framework.Factories.Placement;
using MediatR;

namespace Framework.CQRS.Query.Placement
{
    public class GetPlacementByIdQuery : IRequest<UpdatePlacementCommand>
    {
        public Guid Id { get; set; }
    }

    public class GetPlacementByIdQueryHandler : IRequestHandler<GetPlacementByIdQuery, UpdatePlacementCommand>
    {
        private readonly IPlacementFactory _placementFactory;

        public GetPlacementByIdQueryHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<UpdatePlacementCommand> Handle(GetPlacementByIdQuery request, CancellationToken cancellationToken)
        {
            return await _placementFactory.GetPlacementByIdAsync(request, cancellationToken);
        }
    }
}
