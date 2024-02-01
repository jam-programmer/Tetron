using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Setting
{
    public class SettingService: ISettingService
    {
        private readonly IEfRepository<SettingEntity> _repository;

        public SettingService(IEfRepository<SettingEntity> repository)
        {
            _repository = repository;
        }
        public async Task InsertAsync(SettingEntity setting)
        {
            await _repository.InsertAsync(setting);
        }

        public async Task UpdateAsync(SettingEntity setting)
        {
            await _repository.UpdateAsync(setting);
        }
    }
}
