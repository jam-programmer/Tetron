using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Reports.Picture
{
    public interface IPictureReport
    {
        Task<List<PictureEntity>?> GetByParentIdAsync(Guid id);
    }
}
