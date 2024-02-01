using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Setting;
using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Query.Setting
{
    public class GetSettingQuery:IRequest<ChangeSetting>
    {
        public bool get { set; get; } = true;
    }

    public class GetSettingQueryHandler : IRequestHandler<GetSettingQuery, ChangeSetting>
    {
        private readonly ISettingFactory _settingFactory;

        public GetSettingQueryHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }
        public async Task<ChangeSetting> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetSettingAsync(null,get:request.get);
        }
    }
}
