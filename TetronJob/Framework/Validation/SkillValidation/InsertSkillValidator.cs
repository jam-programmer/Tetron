using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.Skill;

namespace Framework.Validation.SkillValidation
{
    public class InsertSkillValidator:BaseValidator<InsertSkillViewModel>
    {
        public InsertSkillValidator()
        {
            RuleFor(f => f.SkillName).NotNull().NotEmpty();
        }

    }
}
