using Application.Models;
using Domain.Enums;
using Framework.CQRS.Command.Master.Introduction;
using Framework.CQRS.Query.Introduction;

namespace Framework.Factories.Introduction
{
    public interface IIntroductionFactory
    {
        Task<Response> InsertIntroductionAsync(InsertIntroductionCommand command,
            CancellationToken cancellationToken);

        Task<List<CQRS.Query.Introduction.Introduction>> GetIntroductionsWithFilter(
            GetIntroductionWithFilterQuery query);

        Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

       Task<Response> UpdateIntroductionAsync(UpdateIntroductionCommand Command, CancellationToken cancellation);
        Task<Response> DeleteIntroductionAsync(DeleteIntroductionCommand Command, CancellationToken cancellation);
        Task<UpdateIntroductionCommand> GetIntroductionByIdAsync(GetIntroductionByIdQuery request, CancellationToken cancellation);

        Task Change(Guid id, ConditionEnum condition,CancellationToken cancellation);


        Task<IntroductionDetail> GetIntroductionDetailByIdAsync(Guid id);

    }
}
