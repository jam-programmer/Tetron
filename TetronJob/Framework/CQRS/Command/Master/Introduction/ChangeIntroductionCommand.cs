using Domain.Enums;
using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class ChangeIntroductionCommand:IRequest
    {
        public Guid Id { set; get; }
        public ConditionEnum Condition { set; get; }
        
    }

    public class ChangeIntroductionCommandHandler : IRequestHandler<ChangeIntroductionCommand>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public ChangeIntroductionCommandHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }

        public async Task Handle(ChangeIntroductionCommand request, CancellationToken cancellationToken)
        {
             await _introductionFactory.Change(request.Id, request.Condition, cancellationToken);
        }
    }
}
