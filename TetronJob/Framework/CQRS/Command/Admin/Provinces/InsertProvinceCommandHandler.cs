using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Province;

using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Command.Admin.Provinces
{
    public class InsertProvinceCommandHandler:IRequestHandler<InsertProvinceViewModel,Response>
    {
        private readonly IProvincesFactory _provincesFactory;

        public InsertProvinceCommandHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<Response> Handle(InsertProvinceViewModel request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.InsertProvinceAsync(request, cancellationToken);
        }
    }
}
