using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.Province;

namespace Framework.Validation.ProvinceValidation
{
    public class UpdateProvinceValidator:BaseValidator<UpdateProvinceViewModel>
    {
        public UpdateProvinceValidator()
        {
            RuleFor(f => f.Name).NotNull().NotEmpty();
        }
    }
}
