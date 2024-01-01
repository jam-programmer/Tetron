using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Query.Admin.Province
{
    public class GetProvincesQueryHandler:IRequestHandler<RequestProvinces,PaginatedList<ProvinceViewModel>>
    {
        public Task<PaginatedList<ProvinceViewModel>> Handle(RequestProvinces request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
