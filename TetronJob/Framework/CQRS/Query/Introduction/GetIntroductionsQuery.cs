using Application.Models;
using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Query.Introduction
{
    public class GetIntroductionsQuery : IRequest<PaginatedList<Introduction>>
    {
        public PaginatedSearchWithSize Paginated = new PaginatedSearchWithSize();
    }

    public class GetIntroductionsQueryHandler : IRequestHandler<GetIntroductionsQuery, PaginatedList<Introduction>>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public GetIntroductionsQueryHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<PaginatedList<Introduction>> Handle(GetIntroductionsQuery request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.GetPagedSearchWithSizeAsync<Introduction>(request.Paginated, cancellationToken);
        }
    }
}
