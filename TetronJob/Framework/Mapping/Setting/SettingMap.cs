using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Framework.CQRS.Command.Setting;
using Mapster;

namespace Framework.Mapping.Setting
{
    public static class SettingMap
    {
        public static TypeAdapterConfig ChangeSettingConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<SettingEntity,ChangeSetting>()
                .Map(a=>a.About,b=>b.About)
                .Map(a=>a.Enamad,b=>b.Enamad)
                .Map(a=>a.Help,b=>b.Help)
                .Map(a=>a.Instagram,b=>b.Instagram)
                .Map(a=>a.Law,b=>b.Law)
                .Map(a=>a.SiteTitle,b=>b.SiteTitle)
                .Map(a=>a.SmsKey,b=>b.SmsKey)
                .Map(a=>a.Telegram,b=>b.Telegram)
                .Map(a=>a.WhatsApp,b=>b.WhatsApp)
                .Compile();
            return config;
        }
    }
}
