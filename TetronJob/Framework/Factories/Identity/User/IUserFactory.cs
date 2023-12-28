using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ViewModels.Role;
using Framework.ViewModels.User;

namespace Framework.Factories.Identity.User
{
    public interface IUserFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> InsertUserAsync(InsertUserViewModel model,CancellationToken cancellationToken = default);
     

    }
}
