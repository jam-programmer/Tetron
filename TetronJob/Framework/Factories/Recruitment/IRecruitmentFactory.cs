using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
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
    }
}
