using Framework.CQRS.Command.Master.Introduction;
using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Query.Introduction
{
    public class GetIntroductionByIdQuery : IRequest<UpdateIntroductionCommand>
    {
        public Guid Id { set; get; }
    }

    public class GetIntroductionByIdQueryHandler : IRequestHandler<GetIntroductionByIdQuery, UpdateIntroductionCommand>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public GetIntroductionByIdQueryHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<UpdateIntroductionCommand> Handle(GetIntroductionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.GetIntroductionByIdAsync(request, cancellationToken);
        }
    }
}
