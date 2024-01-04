using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.City;
using Framework.ViewModels.City;
using MediatR;

namespace Framework.CQRS.Command.Admin.City
{
    public class InsertCityCommandHandler:IRequestHandler<InsertCityViewModel ,Response>
    {
        private readonly ICityFactory _cityFactory;

        public InsertCityCommandHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }
        public async Task<Response> Handle(InsertCityViewModel request, CancellationToken cancellationToken)
        {
            return await _cityFactory.InsertCityAsync(request, cancellationToken);
        }
    }
}
