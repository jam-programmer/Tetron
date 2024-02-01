using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class DeleteIntroductionCommand:IRequest<Response>
    {
        public Guid Id { set; get; }
    }

    public class DeleteIntroductionCommandHandler : IRequestHandler<DeleteIntroductionCommand, Response>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public DeleteIntroductionCommandHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<Response> Handle(DeleteIntroductionCommand request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.DeleteIntroductionAsync(request, cancellationToken);
        }
    }
}
