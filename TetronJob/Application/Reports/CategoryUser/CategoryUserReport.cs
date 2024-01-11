using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.CategoryUser
{
    public class CategoryUserReport : ICategoryUserReport
    {
        private readonly IEfRepository<CategoryUserEntity> _repository;

        public CategoryUserReport(IEfRepository<CategoryUserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryUserEntity>>

            GetCategoriesByUserIdAsync(Guid userId, CancellationToken cancellation)
        {
            var query = await _repository.GetByQueryAsync();
            return await query.Where(w => w.UserId == userId).ToListAsync(cancellation);
        }

        public async Task<bool> CheckExistCategoryAsync(Guid userId, CancellationToken cancellation)
        {
            var query= await _repository.GetByQueryAsync();
            return await query.AnyAsync(a => a.UserId == userId, cancellationToken: cancellation);
        }
    }
}
