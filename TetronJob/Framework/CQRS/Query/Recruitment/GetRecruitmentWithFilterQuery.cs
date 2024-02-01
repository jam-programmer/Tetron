using Domain.Enums;
using Framework.CQRS.Query.Introduction;
using Framework.Factories.Recruitment;
using MediatR;

namespace Framework.CQRS.Query.Recruitment
{
    public class GetRecruitmentWithFilterQuery : IRequest<List<Recruitment>>
    {
        public Filter Filter { set; get; }
    }

    public class GetRecruitmentsWithFilterQueryHandler : IRequestHandler<GetRecruitmentWithFilterQuery, List<Recruitment>>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public GetRecruitmentsWithFilterQueryHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }
        public async Task<List<Recruitment>> Handle(GetRecruitmentWithFilterQuery request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.GetRecruitmentsWithFilter(request);
        }
    }

    public class Recruitment
    {
        public ConditionEnum Condition { set; get; }
        public string? RecruitmentType { set; get; }
        public string? RecruitmentPhoneNumber { set; get; }
        public Guid Id { set; get; }
        public string? RecruitmentTitle { set; get; }
        public string? RecruitmentImage { set; get; }
    }
}
