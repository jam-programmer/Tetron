using FluentValidation;
using Framework.Common;
using Framework.ViewModels.Province;

namespace Framework.Validation.ProvinceValidation
{
    public class InsertProvinceValidator : BaseValidator<InsertProvinceViewModel>
    {
        public InsertProvinceValidator()
        {
            RuleFor(f => f.Name).NotNull().NotEmpty();
        }
    }
}
