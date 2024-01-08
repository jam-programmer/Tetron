using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Framework.Common;
using Framework.ViewModels.Category;

namespace Framework.Validation.CategoryValidation
{
    public class UpdateCategoryValidator:BaseValidator<UpdateCategoryViewModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(f => f.Name).NotNull();
            RuleFor(f => f.Color).NotNull();
        }
    }
}
