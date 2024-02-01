using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Setting;
using Framework.CQRS.Query.Setting;

namespace Framework.Factories.Setting
{
    public interface ISettingFactory
    {
        Task<ChangeSetting> GetSettingAsync(ChangeSetting? model,bool? get=false);
        Task<HelpViewModel> GetHelpAsync();
        Task<LawViewModel> GetLawAsync();

        Task<AboutViewModel> GetAboutAsync();
    }
}
