using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Province;
using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Query.Admin.Province
{
    public class GetSelectListProvincesQueryHandler:
        IRequestHandler<RequestGetProvinces,List<ProvinceViewModel>>
    {
        private readonly IProvincesFactory _provincesFactory;

        public GetSelectListProvincesQueryHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<List<ProvinceViewModel>> Handle(RequestGetProvinces request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.GetProvincesAsync();
        }
    }
}
