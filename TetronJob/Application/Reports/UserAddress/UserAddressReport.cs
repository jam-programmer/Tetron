using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.UserAddress
{
    public class UserAddressReport:IUserAddressReport
    {
        private readonly IEfRepository<UserAddressEntity> _repository;

        public UserAddressReport(IEfRepository<UserAddressEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExistUserAddressAsync(Guid id)
        {
            var query = await _repository.GetByQueryAsync();
            return query.Any(a=>a.UserId==id);
        }

        public async Task<UserAddressEntity?> GetUserAddressByIdAsync(Guid id)
        {
            IQueryable<UserAddressEntity?> query= await _repository.GetByQueryAsync();
            return await query.SingleOrDefaultAsync(s => s!.UserId == id);
        }
    }
}
