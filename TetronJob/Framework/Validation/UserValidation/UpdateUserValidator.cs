using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.User;

namespace Framework.Validation.UserValidation
{
    public class UpdateUserValidator:BaseValidator<UpdateUserViewModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(f => f.UserName).NotEmpty().NotNull();
            RuleFor(f => f.FullName).NotEmpty().NotNull();
            RuleFor(f => f.Email).NotEmpty().NotNull();
         
            RuleFor(f => f.PhoneNumber).NotEmpty().NotNull();
        }
    }
}
