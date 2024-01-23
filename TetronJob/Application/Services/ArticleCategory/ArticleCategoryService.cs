using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.ArticleCategory
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IEfRepository<ArticleCategoryEntity> _repository;

        public ArticleCategoryService(IEfRepository<ArticleCategoryEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(ArticleCategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.InsertAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(ArticleCategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.UpdateAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> DeleteAsync(ArticleCategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.DeleteAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }
    }
}
