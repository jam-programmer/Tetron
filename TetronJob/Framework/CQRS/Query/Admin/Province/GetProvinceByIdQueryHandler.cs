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
    public class GetProvinceByIdQueryHandler:IRequestHandler<RequestGetProvinceById,UpdateProvinceViewModel>
    {
        private readonly IProvincesFactory _provincesFactory;

        public GetProvinceByIdQueryHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<UpdateProvinceViewModel> Handle(RequestGetProvinceById request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.GetProvinceByIdAsync(request, cancellationToken);
        }
    }
}
