using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Query.Setting
{
    public class GetLawQuery:IRequest<LawViewModel>
    {
    }


    public class GetLawQueryHandler : IRequestHandler<GetLawQuery, LawViewModel>
    {
        private readonly ISettingFactory _settingFactory;

        public GetLawQueryHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }
        public async Task<LawViewModel> Handle(GetLawQuery request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetLawAsync();
        }
    }

    public class LawViewModel
    {
        public string? Law { set; get; }
    }
}
