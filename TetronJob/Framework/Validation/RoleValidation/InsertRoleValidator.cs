using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.Role;

namespace Framework.Validation.RoleValidation
{
    public class InsertRoleValidator:BaseValidator<InsertRoleViewModel>
    {
        public InsertRoleValidator()
        {
            RuleFor(f => f.Name).NotNull()
                .WithMessage("نام سیستمی نقش الزامی می باشد.");
        }
    }
}
