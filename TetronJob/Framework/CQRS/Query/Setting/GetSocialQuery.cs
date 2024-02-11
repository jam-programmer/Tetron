using Framework.Factories.Setting;
using MediatR;

namespace Framework.CQRS.Query.Setting
{
    public class GetSocialQuery : IRequest<Social>
    {
    }


    public class GetSocialQueryHandler : IRequestHandler<GetSocialQuery, Social>
    {
        private readonly ISettingFactory _settingFactory;

        public GetSocialQueryHandler(ISettingFactory settingFactory)
        {
            _settingFactory = settingFactory;
        }
        public async Task<Social> Handle(GetSocialQuery request, CancellationToken cancellationToken)
        {
            return await _settingFactory.GetSocialAsync();
        }
    }

    public class Social
    {
        public string? Instagram { set; get; }
        public string? Telegram { set; get; }
        public string? WhatsApp { set; get; }
    }
}
