
using Application.Models;
using Domain.Entities;

namespace Application.Services.Contact
{
    public interface IContactService
    {
        Task<Response> InsertAsync(ContactUsEntity entity);
    }
}
