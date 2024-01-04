using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.City;
using Framework.ViewModels.User;

namespace Framework.Validation.CityValidation
{
    public class UpdateCityValidator:BaseValidator<UpdateCityViewModel>
    {
        public UpdateCityValidator()
        {
            RuleFor(f => f.Name).NotNull().NotEmpty();
        }
    }
}
