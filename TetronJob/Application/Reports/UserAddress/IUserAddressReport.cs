using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Reports.UserAddress
{
    public interface IUserAddressReport
    {
        Task<bool> ExistUserAddressAsync(Guid id);
        Task<UserAddressEntity?> GetUserAddressByIdAsync(Guid id);
    }
}
