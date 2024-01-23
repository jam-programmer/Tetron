using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Slider
{
    public class SliderService : ISliderService
    {
        private readonly IEfRepository<SliderEntity> _repository;

        public SliderService(IEfRepository<SliderEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(SliderEntity slider, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.InsertAsync(slider);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }

        public async Task<Response> UpdateAsync(SliderEntity slider, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.UpdateAsync(slider);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }

        public async Task<Response> DeleteAsync(SliderEntity slider, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.DeleteAsync(slider);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }
    }
}
