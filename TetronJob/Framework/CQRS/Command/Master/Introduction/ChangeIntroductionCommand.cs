using Application.Models;
using Domain.Enums;
using Framework.Factories.Introduction;
using Framework.Factories.Sender;
using MediatR;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class ChangeIntroductionCommand : IRequest
    {
        public Guid Id { set; get; }
        public ConditionEnum Condition { set; get; }

    }

    public class ChangeIntroductionCommandHandler : IRequestHandler<ChangeIntroductionCommand>
    {
        private readonly IIntroductionFactory _introductionFactory;
        private readonly ISenderFactory _senderFactory;

        public ChangeIntroductionCommandHandler(IIntroductionFactory introductionFactory, ISenderFactory senderFactory)
        {
            _introductionFactory = introductionFactory;
            _senderFactory = senderFactory;
        }

        public async Task Handle(ChangeIntroductionCommand request, CancellationToken cancellationToken)
        {
            var result = await _introductionFactory.Change(request.Id, request.Condition, cancellationToken);
            if (result.IsSuccess == true)
            {
                Dictionary<string, string>? data = (Dictionary<string, string>)result.Data!;
                if (request.Condition == ConditionEnum.Confirmation)
                {
                    var name = data["Name"];
                    var number = data["PhoneNumber"];
                    await _senderFactory.Accept(name,number);
                } if (request.Condition == ConditionEnum.NonApproval)
                {
                    var name = data["Name"];
                    var number = data["PhoneNumber"];
                    await _senderFactory.Cancel(name,number);
                }
            }
        }
    }
}