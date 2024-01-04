using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Province;
using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Query.Admin.Province
{
    public class GetProvincesQueryHandler:IRequestHandler<RequestProvinces,PaginatedList<ProvinceViewModel>>
    {
        private readonly IProvincesFactory _provincesFactory;

        public GetProvincesQueryHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<PaginatedList<ProvinceViewModel>> Handle(RequestProvinces request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.GetPagedSearchWithSizeAsync<ProvinceViewModel>(request.Paginated!,
                cancellationToken);
        }
    }
}
