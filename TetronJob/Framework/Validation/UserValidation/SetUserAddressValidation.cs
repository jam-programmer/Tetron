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
    public class SetUserAddressValidation:BaseValidator<SetUserAddressViewModel>
    {
        public SetUserAddressValidation()
        {
            RuleFor(f => f.CityId).NotNull();
            RuleFor(f => f.ProvinceId).NotNull();
        }
    }
}
