using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.Picture
{
    public interface IPictureService
    {
        Task InsertAsync(PictureEntity picture);
        Task DeleteAsync(PictureEntity picture);
        Task DeleteAsync(List<PictureEntity> pictures);
    }
}
