using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Recruitment;
using MediatR;

namespace Framework.CQRS.Command.Master.Recruitment
{
    public class DeleteRecruitmentCommand:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteRecruitmentCommandHandler : IRequestHandler<DeleteRecruitmentCommand, Response>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public DeleteRecruitmentCommandHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }
        public async Task<Response> Handle(DeleteRecruitmentCommand request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.DeleteRecruitmentAsync(request, cancellationToken);
        }
    }
}
