using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Skill;
using Framework.ViewModels.Skill;
using MediatR;

namespace Framework.CQRS.Command.Admin.Skill
{
    public class DeleteSkillCommandHandler:IRequestHandler<DeleteSkillViewModel,Response>
    {
        private readonly ISkillFactory _skillFactory;

        public DeleteSkillCommandHandler(ISkillFactory skillFactory)
        {
            _skillFactory = skillFactory;
        }
        public async Task<Response> Handle(DeleteSkillViewModel request, CancellationToken cancellationToken)
        {
            return await _skillFactory.DeleteSkillAsync(request, cancellationToken);
        }
    }
}
