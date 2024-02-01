using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Enums;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Command.Master.Recruitment;
using Framework.CQRS.Query.Placement;
using Framework.CQRS.Query.Recruitment;

namespace Framework.Factories.Recruitment
{
    public interface IRecruitmentFactory
    {
        Task<List<CQRS.Query.Recruitment.Recruitment>>
            GetRecruitmentsWithFilter(GetRecruitmentWithFilterQuery query);
        Task<Response> InsertRecruitmentAsync(InsertRecruitmentCommand command, CancellationToken cancellation);





        Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> UpdateRecruitmentAsync(UpdateRecruitmentCommand command, CancellationToken cancellation);

        Task<Response> DeleteRecruitmentAsync(DeleteRecruitmentCommand command, CancellationToken cancellation);

        Task<UpdateRecruitmentCommand> GetRecruitmentByIdAsync(GetRecruitmentByIdQuery request, CancellationToken cancellation);


        Task Change(Guid id, ConditionEnum condition, CancellationToken cancellation);

        Task<RecruitmentDetail> GetRecruitmentDetailByIdAsync(Guid id);







    }
}
