using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Reports.Setting;
using Application.Services.Setting;
using Domain.Entities;
using Framework.CQRS.Command.Setting;
using Framework.CQRS.Query.Setting;
using Framework.Mapping.Setting;
using Mapster;

namespace Framework.Factories.Setting
{
    public class SettingFactory : ISettingFactory
    {
        private readonly ISettingReport _report;
        private readonly ISettingService _service;

        public SettingFactory(ISettingReport report, ISettingService service)
        {
            _report = report;
            _service = service;
        }
        public async Task<ChangeSetting> GetSettingAsync(ChangeSetting model, bool? get=false)
        {
            ChangeSetting viewModel = new ChangeSetting();
            var setting = await _report.GetSettingAsync();
            if (setting == null)
            {
                SettingEntity newSetting = new SettingEntity();
                if (model != null)
                {
                    newSetting = model.Adapt<SettingEntity>();
                }

                await _service.InsertAsync(newSetting);
                viewModel = newSetting.Adapt<ChangeSetting>();
            }
            else
            {
                if (get == false)
                {
                    var id = setting.Id;
                    setting = model.Adapt<SettingEntity>(SettingMap.ChangeSettingConfig());
                    setting.Id = id;
                
                    await _service.UpdateAsync(setting);
                }
                else
                {
                    viewModel = setting.Adapt<ChangeSetting>();

                }

            }


            return viewModel;
        }

        public async Task<HelpViewModel> GetHelpAsync()
        {
            var setting = await _report.GetSettingAsync();
            HelpViewModel help = setting.Adapt<HelpViewModel>();
            return help;
        }

        public async Task<LawViewModel> GetLawAsync()
        {
            var setting = await _report.GetSettingAsync();
            LawViewModel law = setting.Adapt<LawViewModel>();
            return law;
        }
    }
}
