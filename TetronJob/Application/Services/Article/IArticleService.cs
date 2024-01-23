using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Article
{
    public interface IArticleService
    {
        Task<Response> InsertAsync(ArticleEntity article, CancellationToken cancellationToken);
        Task<Response> UpdateAsync(ArticleEntity article, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(ArticleEntity article, CancellationToken cancellationToken);
    }
}
