using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.UserAddress
{
    public interface IUserAddressService
    {
        Task<Response> InsertAsync(UserAddressEntity entity);
        Task<Response> UpdateAsync(UserAddressEntity entity);

    }
}
