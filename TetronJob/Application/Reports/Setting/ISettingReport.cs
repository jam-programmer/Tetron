using Domain.Entities;

namespace Application.Reports.Setting
{
    public interface ISettingReport
    {
        Task<SettingEntity?> GetSettingAsync();
    }
}
