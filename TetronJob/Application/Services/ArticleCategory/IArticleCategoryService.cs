using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        Task<Response> InsertAsync(ArticleCategoryEntity category, CancellationToken cancellationToken);
        Task<Response> UpdateAsync(ArticleCategoryEntity category, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(ArticleCategoryEntity category, CancellationToken cancellationToken);
    }
}
