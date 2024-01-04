using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.City;
using Framework.Validation.CityValidation;
using Framework.ViewModels.City;
using MediatR;

namespace Framework.CQRS.Command.Admin.City
{
    public class UpdateCityCommandHandler:IRequestHandler<UpdateCityViewModel,Response>
    {
        private readonly ICityFactory _cityFactory;

        public UpdateCityCommandHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }
        public async Task<Response> Handle(UpdateCityViewModel request, CancellationToken cancellationToken)
        {
           return await _cityFactory.UpdateCityAsync(request, cancellationToken);
        }
    }
}
