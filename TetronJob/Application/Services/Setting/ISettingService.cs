using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.Setting
{
    public interface ISettingService
    {
        Task InsertAsync(SettingEntity  setting);
        Task UpdateAsync(SettingEntity  setting);
    }
}
