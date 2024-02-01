
using System.Diagnostics.Contracts;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Contact
{
    public class ContactService: IContactService
    {
        private readonly IEfRepository<ContactUsEntity> _repository;

        public ContactService(IEfRepository<ContactUsEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(ContactUsEntity entity)
        {
            Response response = new();
            try
            {
                await _repository.InsertAsync(entity);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
              //todo
            }
            return response;
        }
    }
}
