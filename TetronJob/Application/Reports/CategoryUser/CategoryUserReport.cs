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
        private readonly IDapper _dapper;

        public CategoryUserReport(IEfRepository<CategoryUserEntity> repository, IDapper dapper)
        {
            _repository = repository;
            _dapper = dapper;
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

        public async Task<List<TModel>> GetUsersCategory<TModel>(Guid? CategoryId, Guid? CityId, Guid? ProvinceId, string search = "")
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("@Search", search);
            parameter.Add("@CategoryId", CategoryId.ToString());
           
        



                parameter.Add("@CityId", CityId == Guid.Empty ? "" : CityId.ToString());

                parameter.Add("@ProvinceId", ProvinceId == Guid.Empty ? "" : ProvinceId.ToString());



            var model = await _dapper.Execute<TModel>("GetCategories", parameter);
            return model;
        }
        
    }
}
