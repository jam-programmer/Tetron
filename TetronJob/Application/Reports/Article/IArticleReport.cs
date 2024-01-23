using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reports.Article
{
    public interface IArticleReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<ArticleEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
