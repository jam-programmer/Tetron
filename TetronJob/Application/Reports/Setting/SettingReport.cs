using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Setting
{
    public class SettingReport : ISettingReport
    {
        private readonly IEfRepository<SettingEntity> _repository;

        public SettingReport(IEfRepository<SettingEntity> repository)
        {
            _repository = repository;
        }
        public async Task<SettingEntity?> GetSettingAsync()
        {
            var query = await _repository.GetByQueryAsync();
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
