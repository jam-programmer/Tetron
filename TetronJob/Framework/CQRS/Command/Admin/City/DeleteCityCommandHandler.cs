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
    public class DeleteCityCommandHandler:IRequestHandler<DeleteCityViewModel,Response>
    {
        private readonly ICityFactory _cityFactory;

        public DeleteCityCommandHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }
        public async Task<Response> Handle(DeleteCityViewModel request, CancellationToken cancellationToken)
        {
            return await _cityFactory.DeleteCityAsync(request, cancellationToken);
        }
    }
}
