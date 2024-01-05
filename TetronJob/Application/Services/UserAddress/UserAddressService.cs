using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.UserAddress
{
    public class UserAddressService:IUserAddressService
    {
        private readonly IEfRepository<UserAddressEntity> _repository;

        public UserAddressService(IEfRepository<UserAddressEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(UserAddressEntity entity)
        {
            Response response = new();
            try
            {
                await _repository.InsertAsync(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                //Todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(UserAddressEntity entity)
        {
            Response response = new();
            try
            {
                await _repository.UpdateAsync(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                //Todo
            }
            return response;
        }
    }
}
