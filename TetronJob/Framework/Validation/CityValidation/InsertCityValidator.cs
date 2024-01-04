using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.City;

namespace Framework.Validation.CityValidation
{
    public class InsertCityValidator:BaseValidator<InsertCityViewModel>
    {
        public InsertCityValidator()
        {
            RuleFor(f => f.Name).NotNull().NotEmpty();

        }
    }
}
