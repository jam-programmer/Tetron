using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Command.Setting
{
    public class ChangeSetting:IRequest<ChangeSetting>
    {
        public string? SiteTitle { set; get; }
        public string? Instagram { set; get; }
        public string? Telegram { set; get; }
        public string? WhatsApp { set; get; }
        public string? SmsKey { set; get; }
        public string? Help { set; get; }
        public string? Law { set; get; }
        public string? Enamad { set; get; }
        public string? About { set; get; }
    }

    public class ChangeSettingHandler : IRequestHandler<ChangeSetting, ChangeSetting>
    {
        private readonly ISettingFactory _settingFactory;

        public ChangeSettingHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }
        public async Task<ChangeSetting> Handle(ChangeSetting request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetSettingAsync(request);
        }
    }
}
