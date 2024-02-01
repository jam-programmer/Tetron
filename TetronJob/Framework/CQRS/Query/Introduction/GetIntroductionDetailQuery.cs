using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Query.Introduction
{
    public class GetIntroductionDetailQuery:IRequest<IntroductionDetail>
    {
        public Guid Id { get; set; }
    }

    public class GetIntroductionDetailQueryHandler : IRequestHandler<GetIntroductionDetailQuery, IntroductionDetail>

    {
        private readonly IIntroductionFactory _introductionFactory;

        public GetIntroductionDetailQueryHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<IntroductionDetail> Handle(GetIntroductionDetailQuery request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.GetIntroductionDetailByIdAsync(request.Id);
        }
    }


    public class IntroductionDetail
    {
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
        public string? IntroductionImage { set; get; }
        public string? IntroductionDescription { set; get; }
        public string? ProvinceName { set; get; }
        public string? CityName { set; get; }
        public string? UserFullName { set; get; }
        public List<string>? Skills { set; get; } = new();
        public List<string>? Images { set; get; } = new();
    }
  
}
