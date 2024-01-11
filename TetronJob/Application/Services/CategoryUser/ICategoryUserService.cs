using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.CategoryUser
{
    public interface ICategoryUserService
    {
        Task<Response> InsertAsync(List<CategoryUserEntity> categoryUser,CancellationToken cancellation);
        Task<Response> DeleteAsync(List<CategoryUserEntity> categoryUser,CancellationToken cancellation);

    }
}
