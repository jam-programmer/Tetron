using Framework.Common;
using Framework.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Framework.Validation.SkillValidation
{
    internal class UpdateSkillValidator : BaseValidator<InsertSkillViewModel>
    {
        public UpdateSkillValidator()
        {
            RuleFor(f => f.SkillName).NotNull().NotEmpty();
        }

    }
}
