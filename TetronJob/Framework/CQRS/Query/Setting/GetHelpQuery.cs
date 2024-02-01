using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Query.Setting
{
    public class GetHelpQuery:IRequest<HelpViewModel>
    {
    }

    public class GetHelpQueryHandler : IRequestHandler<GetHelpQuery, HelpViewModel>
    {
        private readonly ISettingFactory _settingFactory;

        public GetHelpQueryHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }
        public async Task<HelpViewModel> Handle(GetHelpQuery request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetHelpAsync();
        }
    }

    public class HelpViewModel
    {
        public string? Help { set; get; }
    }
}
