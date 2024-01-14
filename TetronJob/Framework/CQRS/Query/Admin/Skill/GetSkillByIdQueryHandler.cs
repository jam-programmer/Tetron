using Application.Models;
using Framework.Factories.Skill;
using Framework.ViewModels.Skill;
using MediatR;

namespace Framework.CQRS.Query.Admin.Skill
{
    public class GetSkillByIdQueryHandler:IRequestHandler<RequestGetSkillById,UpdateSkillViewModel>
    {
        private readonly ISkillFactory  _skillFactory;

        public GetSkillByIdQueryHandler(ISkillFactory skillFactory)
        {
            _skillFactory = skillFactory;
        }
        public async Task<UpdateSkillViewModel> Handle(RequestGetSkillById request, CancellationToken cancellationToken)
        {
            return await _skillFactory.GetSkillByIdAsync(request, cancellationToken);
        }
    }
}
