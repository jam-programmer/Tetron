using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Picture
{
    public class PictureService:IPictureService
    {
        private readonly IEfRepository<PictureEntity> _repository;

        public PictureService(IEfRepository<PictureEntity> repository)
        {
            _repository = repository;
        }
        public async Task InsertAsync(PictureEntity picture)
        {
            try
            {
                await _repository.InsertAsync(picture);
               
            }
            catch (Exception e)
            {
              
            }
        }

        public async Task DeleteAsync(PictureEntity picture)
        {
            try
            {
                await _repository.DeleteAsync(picture);
               
            }
            catch (Exception e)
            {
                
            }
        }

        public async Task DeleteAsync(List<PictureEntity> pictures)
        {
            try
            {
                await _repository.DeleteListAsync(pictures);

            }
            catch (Exception e)
            {
            }
        }
    }
}
