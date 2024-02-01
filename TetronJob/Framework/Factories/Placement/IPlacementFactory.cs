using Application.Models;
using Domain.Enums;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Query.Placement;

namespace Framework.Factories.Placement
{
    public interface IPlacementFactory
    {
        Task<List<CQRS.Query.Placement.Placement>>
            GetPlacementsWithFilter(GetPlacementWithFilterQuery query);
        Task<Response> InsertPlacementAsync(InsertPlacementCommand command, CancellationToken cancellation);



        Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> UpdatePlacementAsync(UpdatePlacementCommand Command, CancellationToken cancellation);
        Task<Response> DeletePlacementAsync(DeletePlacementCommand Command, CancellationToken cancellation);
        Task<UpdatePlacementCommand> GetPlacementByIdAsync(GetPlacementByIdQuery request, CancellationToken cancellation);



        Task Change(Guid id, ConditionEnum condition, CancellationToken cancellation);






    }
}
