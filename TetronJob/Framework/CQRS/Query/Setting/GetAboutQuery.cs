

using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Query.Setting
{
    public class GetAboutQuery:IRequest<AboutViewModel>
    {
    }


    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, AboutViewModel>
    {
        private readonly ISettingFactory _settingFactory;

        public GetAboutQueryHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }

        public async Task<AboutViewModel> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetAboutAsync();
        }
    }

    public class AboutViewModel
    {
        public string? Enamad { set; get; }
        public string? About { set; get; }
        public string? Instagram { set; get; }
        public string? Telegram { set; get; }
        public string? WhatsApp { set; get; }
        public string? Email { set; get; }
        public string? Number { set; get; }
    }
}
