using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Extensions
{
    //public static class QueryableExtensions
    //{
    //    public static async Task<PaginatedList<TEntity>> GetPagedAsync<TEntity>
    //        (this IQueryable<TEntity> query, Pagination page) where  TEntity :BaseEntity
    //    {
    //        var entities = query;
    //        int count = query.Count();
    //        int pageSkip = (page.Index - 1) * page.Size;
    //        int pageCount = count / page.Size;
    //        if (count % page.Size != 0)
    //        {
    //            pageCount++;
    //        }
            
    //        entities = entities.Skip(pageSkip).Take(page.Size);
    //        PaginatedList<TEntity> paginated = new PaginatedList<TEntity>();
    //        paginated.PageCount = pageCount;
    //        paginated.List =await entities.ToListAsync();
    //        return paginated;
    //    }
    //}

}