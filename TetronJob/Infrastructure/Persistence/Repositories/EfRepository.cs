using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Persistence.Repositories
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlServerContext _context;

        public EfRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await SaveChangeAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return (await _context.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(s=>s.Id==id))!;
        }

        public Task<IQueryable<TEntity>> GetByQueryAsync()
        {
            return Task.FromResult(_context.Set<TEntity>().AsQueryable());
        }

        public async Task<TEntity> GetDeletedByIdAsync(Guid id)
        {
            return (await _context.Set<TEntity>().IgnoreQueryFilters().SingleOrDefaultAsync(s => s.Id == id))!;
        }

        public async Task<ICollection<TEntity>> GetListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangeAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await SaveChangeAsync();
        }

      
    }
}
