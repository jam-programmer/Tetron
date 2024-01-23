using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly IEfRepository<ArticleEntity> _repository;

        public ArticleService(IEfRepository<ArticleEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(ArticleEntity article, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.InsertAsync(article);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(ArticleEntity article, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.UpdateAsync(article);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> DeleteAsync(ArticleEntity article, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.DeleteAsync(article);
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
