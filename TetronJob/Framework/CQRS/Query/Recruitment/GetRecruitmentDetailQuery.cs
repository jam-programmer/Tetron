using Framework.Factories.Recruitment;
using MediatR;

namespace Framework.CQRS.Query.Recruitment
{
    public class GetRecruitmentDetailQuery:IRequest<RecruitmentDetail>
    {
        public Guid Id { get; set; }
    }

    public class GetRecruitmentDetailQueryHandler : IRequestHandler<GetRecruitmentDetailQuery, RecruitmentDetail>

    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public GetRecruitmentDetailQueryHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }
        public async Task<RecruitmentDetail> Handle(GetRecruitmentDetailQuery request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.GetRecruitmentDetailByIdAsync(request.Id);
        }
    }

    public class RecruitmentDetail
    {
        public string? RecruitmentType { set; get; }
        public string? RecruitmentPhoneNumber { set; get; }
        public string? RecruitmentAddress { set; get; }
        public string? RecruitmentDescription { set; get; }
        public string? RecruitmentTitle { set; get; }
        public string? RecruitmentImage { set; get; }
        public List<string>? Images { set; get; } = new();
        public string? ProvinceName { set; get; }
        public string? CityName { set; get; }
        public string? UserFullName { set; get; }
    }
}
