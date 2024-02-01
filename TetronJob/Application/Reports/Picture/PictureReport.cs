using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Picture
{
    public class PictureReport: IPictureReport
    {
        private readonly IEfRepository<PictureEntity> _repository;

        public PictureReport(IEfRepository<PictureEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<PictureEntity>?> GetByParentIdAsync(Guid id)
        {
            var query = await _repository.GetByQueryAsync();
            query=query.Where(x => x.ParentId == id);
            return await query.ToListAsync();
        }
    }
}
