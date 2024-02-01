using Application.Models;
using Framework.Factories.Placement;
using MediatR;

namespace Framework.CQRS.Command.Master.Placement
{
    public class DeletePlacementCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeletePlacementCommandHandler : IRequestHandler<DeletePlacementCommand, Response>
    {
        private readonly IPlacementFactory _placementFactory;

        public DeletePlacementCommandHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<Response> Handle(DeletePlacementCommand request, CancellationToken cancellationToken)
        {
            return await _placementFactory.DeletePlacementAsync(request, cancellationToken);
        }
    }
}
