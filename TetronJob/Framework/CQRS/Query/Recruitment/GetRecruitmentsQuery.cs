using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Recruitment;
using MediatR;

namespace Framework.CQRS.Query.Recruitment
{
    public class GetRecruitmentsQuery:IRequest<PaginatedList<Recruitment>>
    {
        public PaginatedSearchWithSize Paginated = new PaginatedSearchWithSize();
    }

    public class GetRecruitmentsQueryHandler : IRequestHandler<GetRecruitmentsQuery, PaginatedList<Recruitment>>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public GetRecruitmentsQueryHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }

        public async Task<PaginatedList<Recruitment>> Handle(GetRecruitmentsQuery request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.GetPagedSearchWithSizeAsync<Recruitment>(request.Paginated,
                cancellationToken);
        }
    }
}
