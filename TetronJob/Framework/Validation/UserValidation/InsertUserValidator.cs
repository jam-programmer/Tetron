using FluentValidation;
using Framework.Common;
using Framework.ViewModels.User;

namespace Framework.Validation.UserValidation
{
    public class InsertUserValidator : BaseValidator<InsertUserViewModel>
    {
        public InsertUserValidator()
        {
            RuleFor(f => f.UserName).NotEmpty().NotNull();
            RuleFor(f => f.FullName).NotEmpty().NotNull();
            RuleFor(f => f.Email).NotEmpty().NotNull();
            RuleFor(f => f.Password).NotEmpty().NotNull();
            RuleFor(f => f.PhoneNumber).NotEmpty().NotNull();
        }
    }

   
}
