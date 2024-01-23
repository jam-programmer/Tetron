using Application.Models;
using Domain.Entities;

namespace Application.Services.Slider
{
    public interface ISliderService
    {
        Task<Response> InsertAsync(SliderEntity slider, CancellationToken cancellationToken);
                                 
        Task<Response> UpdateAsync(SliderEntity slider, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(SliderEntity slider, CancellationToken cancellationToken);
    }
}
