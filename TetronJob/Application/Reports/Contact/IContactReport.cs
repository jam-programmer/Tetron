using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Reports.Contact
{
    public interface IContactReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
    }
}
