using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Master.Recruitment;
using Framework.Factories.Recruitment;
using MediatR;

namespace Framework.CQRS.Query.Recruitment
{
    public class GetRecruitmentByIdQuery:IRequest<UpdateRecruitmentCommand>
    {
        public Guid Id { get; set; }
    }

    public class GetRecruitmentByIdQueryHandler : IRequestHandler<GetRecruitmentByIdQuery, UpdateRecruitmentCommand>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public GetRecruitmentByIdQueryHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }
        public async Task<UpdateRecruitmentCommand> Handle(GetRecruitmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.GetRecruitmentByIdAsync(request, cancellationToken);
        }
    }





}
